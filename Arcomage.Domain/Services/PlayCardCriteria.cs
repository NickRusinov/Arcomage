using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Services
{
    public class PlayCardCriteria : IPlayCardCriteria
    {
        private readonly PlayerMode playerMode;

        public PlayCardCriteria(PlayerMode playerMode)
        {
            this.playerMode = playerMode;
        }

        public bool CanPlayCard(Game game, int cardIndex)
        {
            var player = game.GetPlayer(playerMode);

            return game.DiscardOnly <= 0 &&
                player.Hand.Cards[cardIndex].IsEnoughResources(player.Resources);
        }
    }
}
