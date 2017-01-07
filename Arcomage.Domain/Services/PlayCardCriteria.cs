using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Services
{
    [Serializable]
    public class PlayCardCriteria : IPlayCardCriteria
    {
        public bool CanPlayCard(Game game, Player player, int cardIndex)
        {
            return game.DiscardOnly <= 0 &&
                player.Hand.Cards[cardIndex].IsEnoughResources(player.Resources);
        }
    }
}
