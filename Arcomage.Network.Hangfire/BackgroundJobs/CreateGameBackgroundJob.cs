using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Network.Requests;
using Autofac;
using Hangfire;
using MediatR;

namespace Arcomage.Network.Hangfire.BackgroundJobs
{
    /// <summary>
    /// Процесс, выполянющий операцию по созданию игровых сессий и распределению готовых к игре игроков по игровым
    /// сессиям
    /// </summary>
    public class CreateGameBackgroundJob
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
        /// <returns>Задача, представляющая выполнение процесса</returns>
        public async Task Start()
        {
            while (true)
            {
                IEnumerable<GameContext> gameContextCollection;
                using (var scope = lifetimeScope.BeginLifetimeScope())
                    gameContextCollection = await InvokeCreateGame(scope);

                using (var scope = lifetimeScope.BeginLifetimeScope())
                    await InvokePlayGame(scope, gameContextCollection);

                await Task.Delay(TimeSpan.FromSeconds(30));
            }
        }

        /// <summary>
        /// Выполняет операцию по созданию игровых сессий и распределению готовых к игре игроков по игровым сессиям 
        /// в указанной области действия контейнера зависимостей и возвращающая список созданных игровых сессий
        /// </summary>
        /// <param name="scope">Область действия контейнера зависимостей</param>
        /// <returns>Задача, представляющая выполнение процесса</returns>
        private async Task<IEnumerable<GameContext>> InvokeCreateGame(ILifetimeScope scope)
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

        /// <summary>
        /// Выполняет операцию по запуску игровых сессий в указанной облати действия контейнера зависимостей
        /// </summary>
        /// <param name="scope">Область действия контейнера зависимостей</param>
        /// <param name="gameContextCollection">Список игровых сессий для запуска</param>
        /// <returns>Задача, представляющая выполнение процесса</returns>
        private async Task InvokePlayGame(ILifetimeScope scope, IEnumerable<GameContext> gameContextCollection)
        {
            var gameContextRepository = scope.Resolve<IRepository<GameContext>>();

            foreach (var gameContext in gameContextCollection)
            {
                var jobId = BackgroundJob.Enqueue<PlayGameBackgroundJob>(job => job.Start(gameContext.Id));
                await gameContextRepository.Update(gameContext, gc => gc.JobId = jobId);
            }
        }
    }
}
