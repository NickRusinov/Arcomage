using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain;
using Arcomage.Network.Repositories;

namespace Arcomage.Network.Jobs
{
    public class GameStatePlayGamePublisher : DecoratorPlayGamePublisher
    {
        private readonly IGameContextRepository gameContextRepository;

        public GameStatePlayGamePublisher(IPlayGamePublisher playGamePublisher, IGameContextRepository gameContextRepository) 
            : base(playGamePublisher)
        {
            this.gameContextRepository = gameContextRepository;
        }

        public override async Task OnStart(GameContext gameContext, Game game)
        {
            gameContext.State = GameState.Playing;
            gameContext.StartedDate = DateTime.UtcNow;

            await gameContextRepository.Save(gameContext);

            await base.OnStart(gameContext, game);
        }

        public override async Task OnFinish(GameContext gameContext, Game game)
        {
            gameContext.State = GameState.Finished;
            gameContext.StartedDate = DateTime.UtcNow;

            await gameContextRepository.Save(gameContext);

            await base.OnFinish(gameContext, game);
        }

        public override async Task OnAfterPlay(GameContext gameContext, Game game)
        {
            gameContext.Version++;

            await gameContextRepository.Save(gameContext);

            await base.OnAfterPlay(gameContext, game);
        }
    }
}
