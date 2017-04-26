using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain;
using Arcomage.Domain.Players;
using Arcomage.Network.Repositories;
using Arcomage.Network.Requests;
using MediatR;

namespace Arcomage.Network.Handlers
{
    public class PlayGameRequestHandler : IAsyncRequestHandler<PlayCardGameRequest>, IAsyncRequestHandler<DiscardCardGameRequest>
    {
        private readonly IGameRepository gameRepository;

        public PlayGameRequestHandler(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public async Task Handle(PlayCardGameRequest message)
        {
            var humanPlayer = await GetHumanPlayer(message.GameContext, message.UserContext);

            humanPlayer.SetPlayResult(new PlayResult(message.Index, true));
        }

        public async Task Handle(DiscardCardGameRequest message)
        {
            var humanPlayer = await GetHumanPlayer(message.GameContext, message.UserContext);

            humanPlayer.SetPlayResult(new PlayResult(message.Index, false));
        }

        private async Task<HumanPlayer> GetHumanPlayer(GameContext gameContext, UserContext userContext)
        {
            var game = await gameRepository.GetById(gameContext.Id) ??
                throw new NetworkException(NetworkResources.NotFoundActiveGame);

            if (gameContext.FirstUser.Id == userContext.Id && game.Players.Kind != PlayerKind.First)
                throw new NetworkException(NetworkResources.NotPlayedHumanPlayer);

            if (gameContext.SecondUser.Id == userContext.Id && game.Players.Kind != PlayerKind.Second)
                throw new NetworkException(NetworkResources.NotPlayedHumanPlayer);

            if (!(game.Players.CurrentPlayer is HumanPlayer humanPlayer))
                throw new NetworkException(NetworkResources.NotPlayedHumanPlayer);

            return humanPlayer;
        }
    }
}
