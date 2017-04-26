using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain;
using Arcomage.Network.Repositories;
using Arcomage.Network.Requests;
using MediatR;

namespace Arcomage.Network.Handlers
{
    public class CreateGameRequestHandler : IAsyncRequestHandler<CreateGameRequest, GameContext>
    {
        private readonly GameBuilder gameBuilder;

        private readonly IGameRepository gameRepository;

        private readonly IGameContextRepository gameContextRepository;

        public CreateGameRequestHandler(GameBuilder gameBuilder, IGameRepository gameRepository, IGameContextRepository gameContextRepository)
        {
            this.gameBuilder = gameBuilder;
            this.gameRepository = gameRepository;
            this.gameContextRepository = gameContextRepository;
        }

        public async Task<GameContext> Handle(CreateGameRequest message)
        {
            var gameContext = GameContext.New(message.FirstUserContext, message.SecondUserContext);
            var gameBuilderContext = gameBuilder.CreateContext();
            var game = gameBuilderContext.Resolve<Game>();

            if (!await gameContextRepository.Add(gameContext))
                throw new NetworkException(NetworkResources.NotAddedNewGameContext);

            if (!await gameRepository.Add(gameContext.Id, game))
                throw new NetworkException(NetworkResources.NotAddedNewGame);

            return gameContext;
        }
    }
}
