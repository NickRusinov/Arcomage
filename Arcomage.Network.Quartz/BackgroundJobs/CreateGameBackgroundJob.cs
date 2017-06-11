using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Network.Requests;
using Autofac;
using MediatR;
using Quartz;

namespace Arcomage.Network.Quartz.BackgroundJobs
{
    /// <summary>
    /// Процесс, выполянющий операцию по созданию игровых сессий и распределению готовых к игре игроков по игровым
    /// сессиям
    /// </summary>
    [DisallowConcurrentExecution]
    public class CreateGameBackgroundJob : IJob
    {
        /// <summary>
        /// Контейнер зависимостей для создания экземпляров сервисов
        /// </summary>
        private readonly ILifetimeScope lifetimeScope;

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="CreateGameBackgroundJob"/>
        /// </summary>
        /// <param name="lifetimeScope">Контейнер зависимостей для создания экземпляров сервисов</param>
        public CreateGameBackgroundJob(ILifetimeScope lifetimeScope)
        {
            this.lifetimeScope = lifetimeScope;
        }

        /// <summary>
        /// Запускает процесс, выполняющий операцию по созданию игровых сессий и распределению готовых к игре игроков 
        /// по игровым сессиям
        /// </summary>
        /// <param name="context">Контекст выполнения процесса</param>
        /// <returns>Задача, представляющая выполнение процесса</returns>
        public async Task Execute(IJobExecutionContext context)
        {
            var gameContextCollection = await InvokeCreateGame(context);
            await InvokePlayGame(context, gameContextCollection);
        }

        /// <summary>
        /// Выполняет операцию по созданию игровых сессий и распределению готовых к игре игроков по игровым сессиям 
        /// в указанной области действия контейнера зависимостей и возвращающая список созданных игровых сессий
        /// </summary>
        /// <param name="context">Контекст выполнения процесса</param>
        /// <returns>Задача, представляющая выполнение процесса</returns>
        private async Task<IEnumerable<GameContext>> InvokeCreateGame(IJobExecutionContext context)
        {
            using (var scope = lifetimeScope.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                var gameContextRepository = scope.Resolve<IRepository<GameContext>>();

                var getConnectingUsersRequest = new GetConnectingUsersRequest();
                var userList = (await mediator.Send(getConnectingUsersRequest)).ToList();

                var gameContextList = new List<GameContext>();

                for (int i = 0, j = 1; j < userList.Count; i += 2, j += 2)
                {
                    var createGameRequest = new CreateGameRequest(userList[i], userList[j]);
                    var gameContext = await mediator.Send(createGameRequest);

                    gameContextList.Add(gameContext);
                }

                if (userList.Count % 2 == 1)
                {
                    var createGameRequest = new CreateGameRequest(userList[userList.Count - 1], User.ComputerUser);
                    var gameContext = await mediator.Send(createGameRequest);

                    gameContextList.Add(gameContext);
                }

                return gameContextList;
            }
        }

        /// <summary>
        /// Выполняет операцию по запуску игровых сессий в указанной облати действия контейнера зависимостей
        /// </summary>
        /// <param name="context">Контекст выполнения процесса</param>
        /// <param name="gameContextCollection">Список игровых сессий для запуска</param>
        /// <returns>Задача, представляющая выполнение процесса</returns>
        private async Task InvokePlayGame(IJobExecutionContext context, 
            IEnumerable<GameContext> gameContextCollection)
        {
            using (var scope = lifetimeScope.BeginLifetimeScope())
            {
                foreach (var gameContext in gameContextCollection)
                {
                    var playGameJobKey = QuartzKeyGenerator.JobForPlayGame(gameContext);
                    var playGameTriggerKey = QuartzKeyGenerator.TriggerForPlayGame(gameContext);
                    
                    var playGameJob = JobBuilder.Create<PlayGameBackgroundJob>().WithIdentity(playGameJobKey)
                        .RequestRecovery().Build();
                    var playGameTrigger = TriggerBuilder.Create().WithIdentity(playGameTriggerKey)
                        .StartNow().WithSimpleSchedule().Build();

                    playGameJob.JobDataMap.Put(PlayGameBackgroundJob.IdKey, gameContext.Id);

                    await context.Scheduler.ScheduleJob(playGameJob, playGameTrigger);
                }
            }
        }
    }
}
