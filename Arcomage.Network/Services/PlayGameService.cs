using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain;
using Arcomage.Domain.Players;
using Arcomage.Network.Queries;
using Arcomage.Network.Repositories;

namespace Arcomage.Network.Services
{
    public class PlayGameService : IPlayGameService
    {
        private readonly IGameRepository gameRepository;

        private readonly IGameContextRepository gameContextRepository;

        private readonly IGetPlayingGameQuery getPlayingGameQuery;

        public PlayGameService(IGameRepository gameRepository, IGameContextRepository gameContextRepository, IGetPlayingGameQuery getPlayingGameQuery)
        {
            this.gameRepository = gameRepository;
            this.gameContextRepository = gameContextRepository;
            this.getPlayingGameQuery = getPlayingGameQuery;
        }

        public async Task PlayCard(UserContext userContext, int cardIndex)
        {
            var humanPlayer = await GetHumanPlayer(userContext);

            humanPlayer.SetPlayResult(new PlayResult(cardIndex, true));
        }

        public async Task DiscardCard(UserContext userContext, int cardIndex)
        {
            var humanPlayer = await GetHumanPlayer(userContext);

            humanPlayer.SetPlayResult(new PlayResult(cardIndex, false));
        }

        private async Task<HumanPlayer> GetHumanPlayer(UserContext userContext)
        {
            var gameContext = await getPlayingGameQuery.Handle(userContext) ??
                throw new NetworkException(NetworkResources.NotFoundActiveGameContext);

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
