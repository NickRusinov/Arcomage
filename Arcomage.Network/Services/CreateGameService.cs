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

        private readonly IUserContextRepository userContextRepository;

        public CreateGameService(GameBuilder gameBuilder, IGameRepository gameRepository, IGameContextRepository gameContextRepository, IUserContextRepository userContextRepository)
        {
            this.gameBuilder = gameBuilder;
            this.gameRepository = gameRepository;
            this.gameContextRepository = gameContextRepository;
            this.userContextRepository = userContextRepository;
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

            await gameContextRepository.Update(gameContext,
                gc => gc.State = GameState.Playing,
                gc => gc.StartedDate = DateTime.UtcNow);

            await userContextRepository.Update(firstUserContext,
                uc => uc.State = UserState.Playing);
            await userContextRepository.Update(secondUserContext,
                uc => uc.State = UserState.Playing);

            var jobId = BackgroundJob.Enqueue<PlayGameJob>(j => j.Start(gameContext));
            
            await gameContextRepository.Update(gameContext, 
                gc => gc.JobId = jobId);

            return gameContext;
        }
    }
}
