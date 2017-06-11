using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Actions;
using Arcomage.Network.Notifications;
using Autofac;
using MediatR;
using Quartz;

namespace Arcomage.Network.Quartz.BackgroundJobs
{
    /// <summary>
    /// Процесс, выполняющий игровой цикл для одной отдельной игровой сессии
    /// </summary>
    public class PlayGameBackgroundJob : IJob
    {
        /// <summary>
        /// Ключ для передачи идентифкатора игры типа <see cref="Guid"/>
        /// </summary>
        public static readonly string IdKey = "Id";

        /// <summary>
        /// Контейнер зависимостей для создания экземпляров сервисов
        /// </summary>
        private readonly ILifetimeScope lifetimeScope;

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="PlayGameBackgroundJob"/>
        /// </summary>
        /// <param name="lifetimeScope">Контейнер зависимостей для создания экземпляров сервисов</param>
        public PlayGameBackgroundJob(ILifetimeScope lifetimeScope)
        {
            this.lifetimeScope = lifetimeScope;
        }

        /// <summary>
        /// Запускает процесс, выполняющий цикл для одной отдельной игровой сессии с указнным идентифкатором
        /// </summary>
        /// <param name="context">Контекст выполнения процесса</param>
        /// <returns>Задача, представляющая выполнение процесса</returns>
        public async Task Execute(IJobExecutionContext context)
        {
            var id = new Guid(context.MergedJobDataMap.GetString(IdKey));
            
            var gameContext = await InvokeGetGameContext(context, id);
            
            await InvokeStartGame(context, gameContext);

            var root = new RootPlayAction(gameContext.Game.PlayAction);
            while (!gameContext.Game.Rule.IsWin(gameContext.Game))
            {
                await InvokeBeforePlayCardGame(context, gameContext);

                context.CancellationToken.ThrowIfCancellationRequested();
                await root.WaitPlay(gameContext.Game);
                context.CancellationToken.ThrowIfCancellationRequested();
                
                await InvokeAfterPlayCardGame(context, gameContext);
            }
            
            await InvokeStopGame(context, gameContext);
        }

        /// <summary>
        /// Выполняет получение экземпляра игровой сессии с указанным идентифкатором в указанной облати действия 
        /// контейнера зависимостей
        /// </summary>
        /// <param name="context">Контекст выполнения процесса</param>
        /// <param name="id">Идентификатор игровой сессии</param>
        /// <returns>Задача, представляющая получение экземпляра игровой сессии</returns>
        private async Task<GameContext> InvokeGetGameContext(IJobExecutionContext context, Guid id)
        {
            using (var scope = lifetimeScope.BeginLifetimeScope())
            {
                var gameContextRepository = scope.Resolve<IRepository<GameContext>>();

                return await gameContextRepository.GetById(id);
            }
        }

        /// <summary>
        /// Выполняет операцию по оповещению о начале игровой сессии в указанной области действия контейнера 
        /// зависимостей
        /// </summary>
        /// <param name="context">Контекст выполнения процесса</param>
        /// <param name="gameContext">Игровая сессия</param>
        /// <returns>Задача, представляющая операцию</returns>
        private async Task InvokeStartGame(IJobExecutionContext context, GameContext gameContext)
        {
            using (var scope = lifetimeScope.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();

                var startGameNotification = new StartGameNotification(gameContext);
                await mediator.Publish(startGameNotification, context.CancellationToken);
            }
        }

        /// <summary>
        /// Выполняет операцию по оповещению о окончании игровой сессии в указанной области действия контейнера 
        /// зависимостей
        /// </summary>
        /// <param name="context">Контекст выполнения процесса</param>
        /// <param name="gameContext">Игровая сессия</param>
        /// <returns>Задача, представляющая операцию</returns>
        private async Task InvokeStopGame(IJobExecutionContext context, GameContext gameContext)
        {
            using (var scope = lifetimeScope.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();

                var stopGameNotification = new StopGameNotification(gameContext);
                await mediator.Publish(stopGameNotification, context.CancellationToken);
            }
        }

        /// <summary>
        /// Выполняет операцию по оповещению перед началом игрового хода в указанной области действия контейнера
        /// зависимостей
        /// </summary>
        /// <param name="context">Контекст выполнения процесса</param>
        /// <param name="gameContext">Игровая сессия</param>
        /// <returns>Задача, представляющпя операцию</returns>
        private async Task InvokeBeforePlayCardGame(IJobExecutionContext context, GameContext gameContext)
        {
            using (var scope = lifetimeScope.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();

                var beforePlayCardGameNotification = new BeforePlayCardGameNotification(gameContext);
                await mediator.Publish(beforePlayCardGameNotification, context.CancellationToken);
            }
        }

        /// <summary>
        /// Выполняет операцию по оповещению после завершения игрового хода в указанной области действия контейнера
        /// зависимостей
        /// </summary>
        /// <param name="context">Контекст выполнения процесса</param>
        /// <param name="gameContext">Игровая сессия</param>
        /// <returns>Задача, представляющпя операцию</returns>
        private async Task InvokeAfterPlayCardGame(IJobExecutionContext context, GameContext gameContext)
        {
            using (var scope = lifetimeScope.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();

                var afterPlayCardGameNotification = new AfterPlayCardGameNotification(gameContext);
                await mediator.Publish(afterPlayCardGameNotification, context.CancellationToken);
            }
        }
    }
}
