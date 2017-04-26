using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Actions;
using Arcomage.Network.Notifications;
using Arcomage.Network.Repositories;
using MediatR;

namespace Arcomage.Network.Jobs
{
    public class PlayGameJob
    {
        private readonly IMediator mediator;

        private readonly IGameRepository gameRepository;

        public PlayGameJob(IMediator mediator, IGameRepository gameRepository)
        {
            this.mediator = mediator;
            this.gameRepository = gameRepository;
        }

        public async Task Start(GameContext gameContext)
        {
            var game = await gameRepository.GetById(gameContext.Id);
            var root = new RootPlayAction(game.PlayAction);

            await mediator.Publish(new StartGameNotification(gameContext));

            while (!game.Rule.IsWin(game))
            {
                await mediator.Publish(new BeforePlayCardGameNotification(gameContext, game));
                await root.WaitPlay(game);
                await mediator.Publish(new AfterPlayCardGameNotification(gameContext, game));
            }

            await mediator.Publish(new StopGameNotification(gameContext));
        }
    }
}
