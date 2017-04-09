using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain;
using Arcomage.Domain.Players;

namespace Arcomage.Network.Domain
{
    public class PlayGameCommand : IPlayGameCommand
    {
        private readonly IGetGameByIdQuery getGameByIdQuery;

        public PlayGameCommand(IGetGameByIdQuery getGameByIdQuery)
        {
            this.getGameByIdQuery = getGameByIdQuery;
        }

        public async Task PlayCard(GameContext gameContext, UserContext userContext, int cardIndex)
        {
            var game = await getGameByIdQuery.Get(gameContext.Id);
            
            if (!(game.Players.CurrentPlayer is HumanPlayer humanPlayer))
                return;

            humanPlayer.SetPlayResult(new PlayResult(cardIndex, true));
        }

        public async Task DiscardCard(GameContext gameContext, UserContext userContext, int cardIndex)
        {
            var game = await getGameByIdQuery.Get(gameContext.Id);

            if (!(game.Players.CurrentPlayer is HumanPlayer humanPlayer))
                return;

            humanPlayer.SetPlayResult(new PlayResult(cardIndex, false));
        }
    }
}
