using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Services
{
    /// <summary>
    /// Критерий возможности активации карты
    /// </summary>
    [Serializable]
    public class PlayCardCriteria : IPlayCardCriteria
    {
        /// <inheritdoc/>
        public bool CanPlayCard(Game game, Player player, int cardIndex)
        {
            var card = player.Hand.Cards[cardIndex];

            return game.DiscardOnly <= 0 &&
                card.Price <= player.Resources[card.Kind].Value;
        }
    }
}
