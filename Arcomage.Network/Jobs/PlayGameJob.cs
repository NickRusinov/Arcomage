using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Actions;
using Arcomage.Network.Repositories;

namespace Arcomage.Network.Jobs
{
    public class PlayGameJob
    {
        private readonly IGameRepository gameRepository;

        private readonly IPlayGamePublisher playGamePublisher;

        public PlayGameJob(IGameRepository gameRepository, IPlayGamePublisher playGamePublisher)
        {
            this.gameRepository = gameRepository;
            this.playGamePublisher = playGamePublisher;
        }

        public async Task Start(GameContext gameContext)
        {
            var game = await gameRepository.GetById(gameContext.Id);
            var root = new RootPlayAction(game.PlayAction);
            
            await playGamePublisher.OnStart(gameContext, game);

            while (!game.Rule.IsWin(game))
            {
                await playGamePublisher.OnBeforePlay(gameContext, game);
                await root.WaitPlay(game);
                await playGamePublisher.OnAfterPlay(gameContext, game);
            }

            await playGamePublisher.OnFinish(gameContext, game);
        }
    }
}
