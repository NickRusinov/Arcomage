using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain;
using Arcomage.Network.Jobs;
using Arcomage.Network.Repositories;
using Hangfire;

namespace Arcomage.Network.Services
{
    public class CreateGameService : ICreateGameService
    {
        private readonly GameBuilder gameBuilder;

        private readonly IGameRepository gameRepository;

        private readonly IGameContextRepository gameContextRepository;

        public CreateGameService(GameBuilder gameBuilder, IGameRepository gameRepository, IGameContextRepository gameContextRepository)
        {
            this.gameBuilder = gameBuilder;
            this.gameRepository = gameRepository;
            this.gameContextRepository = gameContextRepository;
        }

        public async Task<GameContext> CreateGame(UserContext firstUserContext, UserContext secondUserContext)
        {
            var gameContext = GameContext.New(firstUserContext, secondUserContext);
            var gameBuilderContext = gameBuilder.CreateContext();
            var game = gameBuilderContext.Resolve<Game>();

            if (!await gameContextRepository.Add(gameContext))
                throw new NetworkException(NetworkResources.NotAddedNewGameContext);

            if (!await gameRepository.Add(gameContext.Id, game))
                throw new NetworkException(NetworkResources.NotAddedNewGame);
            
            BackgroundJob.Enqueue<PlayGameJob>(j => j.Start(gameContext));

            return gameContext;
        }
    }
}
