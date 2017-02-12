using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Players;

namespace Arcomage.Domain.Services
{
    /// <summary>
    /// Критерий возможности сброса карты
    /// </summary>
    [Serializable]
    public class DiscardCardCriteria : IDiscardCardCriteria
    {
        /// <inheritdoc/>
        public bool CanDiscardCard(Game game, Player player, int cardIndex)
        {
            return true;
        }
    }
}
