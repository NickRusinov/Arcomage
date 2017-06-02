using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain;
using Arcomage.Network.Requests;
using MediatR;

namespace Arcomage.Network.RequestHandlers
{
    public class CreateGameRequestHandler : IAsyncRequestHandler<CreateGameRequest, GameContext>
    {
        private readonly GameBuilder<GameContext> gameBuilder;

        private readonly IRepository<GameContext> gameContextRepository;

        public CreateGameRequestHandler(GameBuilder<GameContext> gameBuilder, IRepository<GameContext> gameContextRepository)
        {
            this.gameBuilder = gameBuilder;
            this.gameContextRepository = gameContextRepository;
        }

        public async Task<GameContext> Handle(CreateGameRequest message)
        {
            var gameContext = new GameContext
            {
                Id = Guid.NewGuid(),
                FirstUser = message.FirstUser, FirstUserId = message.FirstUser.Id,
                SecondUser = message.SecondUser, SecondUserId = message.SecondUser.Id
            };
            var gameBuilderContext = gameBuilder.CreateContext(gameContext);
            gameContext.Game = gameBuilderContext.Resolve<Game>();

            if (!await gameContextRepository.Add(gameContext))
                throw new NetworkException(Resources.NotAddedNewGameContext);

            return gameContext;
        }
    }
}
