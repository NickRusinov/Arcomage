using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Actions;
using Arcomage.Network.Notifications;
using Autofac;
using MediatR;

namespace Arcomage.Network.Hangfire.BackgroundJobs
{
    /// <summary>
    /// Процесс, выполняющий игровой цикл для одной отдельной игровой сессии
    /// </summary>
    public class PlayGameBackgroundJob
    {
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
        /// <param name="id">Идентифкатор игровой сессии</param>
        /// <returns>Задача, представляющая выполнение процесса</returns>
        public async Task Start(Guid id)
        {
            GameContext gameContext;
            using (var scope = lifetimeScope.BeginLifetimeScope())
                gameContext = await InvokeGetGameContext(scope, id);

            using (var scope = lifetimeScope.BeginLifetimeScope())
                await InvokeStartGame(scope, gameContext);

            var root = new RootPlayAction(gameContext.Game.PlayAction);
            while (!gameContext.Game.Rule.IsWin(gameContext.Game))
            {
                using (var scope = lifetimeScope.BeginLifetimeScope())
                    await InvokeBeforePlayCardGame(scope, gameContext);

                await root.WaitPlay(gameContext.Game);

                using (var scope = lifetimeScope.BeginLifetimeScope())
                    await InvokeAfterPlayCardGame(scope, gameContext);
            }

            using (var scope = lifetimeScope.BeginLifetimeScope())
                await InvokeStopGame(scope, gameContext);
        }

        /// <summary>
        /// Выполняет получение экземпляра игровой сессии с указанным идентифкатором в указанной облати действия 
        /// контейнера зависимостей
        /// </summary>
        /// <param name="scope">Область действия контейнера зависимостей</param>
        /// <param name="id">Идентификатор игровой сессии</param>
        /// <returns>Задача, представляющая получение экземпляра игровой сессии</returns>
        private async Task<GameContext> InvokeGetGameContext(ILifetimeScope scope, Guid id)
        {
            var gameContextRepository = scope.Resolve<IRepository<GameContext>>();

            return await gameContextRepository.GetById(id);
        }

        /// <summary>
        /// Выполняет операцию по оповещению о начале игровой сессии в указанной области действия контейнера 
        /// зависимостей
        /// </summary>
        /// <param name="scope">Область действия контейнера зависимостей</param>
        /// <param name="gameContext">Игровая сессия</param>
        /// <returns>Задача, представляющая операцию</returns>
        private async Task InvokeStartGame(ILifetimeScope scope, GameContext gameContext)
        {
            var mediator = scope.Resolve<IMediator>();

            var startGameNotification = new StartGameNotification(gameContext);
            await mediator.Publish(startGameNotification);
        }

        /// <summary>
        /// Выполняет операцию по оповещению о окончании игровой сессии в указанной области действия контейнера 
        /// зависимостей
        /// </summary>
        /// <param name="scope">Область действия контейнера зависимостей</param>
        /// <param name="gameContext">Игровая сессия</param>
        /// <returns>Задача, представляющая операцию</returns>
        private async Task InvokeStopGame(ILifetimeScope scope, GameContext gameContext)
        {
            var mediator = scope.Resolve<IMediator>();

            var stopGameNotification = new StopGameNotification(gameContext);
            await mediator.Publish(stopGameNotification);
        }

        /// <summary>
        /// Выполняет операцию по оповещению перед началом игрового хода в указанной области действия контейнера
        /// зависимостей
        /// </summary>
        /// <param name="scope">Область действия контейнера зависимостей</param>
        /// <param name="gameContext">Игровая сессия</param>
        /// <returns>Задача, представляющпя операцию</returns>
        private async Task InvokeBeforePlayCardGame(ILifetimeScope scope, GameContext gameContext)
        {
            var mediator = scope.Resolve<IMediator>();

            var beforePlayCardGameNotification = new BeforePlayCardGameNotification(gameContext);
            await mediator.Publish(beforePlayCardGameNotification);
        }

        /// <summary>
        /// Выполняет операцию по оповещению после завершения игрового хода в указанной области действия контейнера
        /// зависимостей
        /// </summary>
        /// <param name="scope">Область действия контейнера зависимостей</param>
        /// <param name="gameContext">Игровая сессия</param>
        /// <returns>Задача, представляющпя операцию</returns>
        private async Task InvokeAfterPlayCardGame(ILifetimeScope scope, GameContext gameContext)
        {
            var mediator = scope.Resolve<IMediator>();
            
            var afterPlayCardGameNotification = new AfterPlayCardGameNotification(gameContext);
            await mediator.Publish(afterPlayCardGameNotification);
        }
    }
}
