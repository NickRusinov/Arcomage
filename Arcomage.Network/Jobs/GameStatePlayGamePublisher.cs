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

        private readonly IUserContextRepository userContextRepository;

        public GameStatePlayGamePublisher(IPlayGamePublisher playGamePublisher, IGameContextRepository gameContextRepository, IUserContextRepository userContextRepository) 
            : base(playGamePublisher)
        {
            this.gameContextRepository = gameContextRepository;
            this.userContextRepository = userContextRepository;
        }

        public override async Task OnFinish(GameContext gameContext, Game game)
        {
            await gameContextRepository.Update(gameContext,
                gc => gc.State = GameState.Finished,
                gc => gc.StartedDate = DateTime.UtcNow);

            await base.OnFinish(gameContext, game);
        }

        public override async Task OnAfterPlay(GameContext gameContext, Game game)
        {
            await gameContextRepository.Update(gameContext,
                gc => gc.Version++);

            await base.OnAfterPlay(gameContext, game);
        }
    }
}
