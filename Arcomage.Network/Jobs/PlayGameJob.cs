using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Actions;
using Arcomage.Network.Notifications;
using MediatR;

namespace Arcomage.Network.Jobs
{
    public class PlayGameJob
    {
        private readonly IMediator mediator;

        private readonly IRepository<GameContext> gameContextRepository;

        public PlayGameJob(IMediator mediator, IRepository<GameContext> gameContextRepository)
        {
            this.mediator = mediator;
            this.gameContextRepository = gameContextRepository;
        }

        public async Task Start(Guid id)
        {
            var gameContext = await gameContextRepository.GetById(id);
            var root = new RootPlayAction(gameContext.Game.PlayAction);

            await mediator.Publish(new StartGameNotification(gameContext));

            while (!gameContext.Game.Rule.IsWin(gameContext.Game))
            {
                await mediator.Publish(new BeforePlayCardGameNotification(gameContext));
                await root.WaitPlay(gameContext.Game);
                await mediator.Publish(new AfterPlayCardGameNotification(gameContext));
            }

            await mediator.Publish(new StopGameNotification(gameContext));
        }
    }
}
