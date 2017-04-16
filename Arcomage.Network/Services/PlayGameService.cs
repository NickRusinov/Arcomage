using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain;
using Arcomage.Domain.Players;
using Arcomage.Network.Repositories;

namespace Arcomage.Network.Services
{
    public class PlayGameService : IPlayGameService
    {
        private readonly IGameRepository gameRepository;

        private readonly IGameContextRepository gameContextRepository;

        public PlayGameService(IGameRepository gameRepository, IGameContextRepository gameContextRepository)
        {
            this.gameRepository = gameRepository;
            this.gameContextRepository = gameContextRepository;
        }

        public async Task PlayCard(Guid userId, int cardIndex)
        {
            var humanPlayer = await GetHumanPlayer(userId);

            humanPlayer.SetPlayResult(new PlayResult(cardIndex, true));
        }

        public async Task DiscardCard(Guid userId, int cardIndex)
        {
            var humanPlayer = await GetHumanPlayer(userId);

            humanPlayer.SetPlayResult(new PlayResult(cardIndex, false));
        }

        private async Task<HumanPlayer> GetHumanPlayer(Guid userId)
        {
            var gameContext = await gameContextRepository.GetByUserId(userId) ??
                throw new NetworkException(NetworkResources.NotFoundActiveGameContext);

            var game = await gameRepository.GetById(gameContext.Id) ??
                throw new NetworkException(NetworkResources.NotFoundActiveGame);

            if (gameContext.FirstUser.Id == userId && game.Players.Kind != PlayerKind.First)
                throw new NetworkException(NetworkResources.NotPlayedHumanPlayer);

            if (gameContext.SecondUser.Id == userId && game.Players.Kind != PlayerKind.Second)
                throw new NetworkException(NetworkResources.NotPlayedHumanPlayer);

            if (!(game.Players.CurrentPlayer is HumanPlayer humanPlayer))
                throw new NetworkException(NetworkResources.NotPlayedHumanPlayer);

            return humanPlayer;
        }
    }
}
