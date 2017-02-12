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
    public interface IDiscardCardCriteria
    {
        /// <summary>
        /// Определяет возможность сброса карты
        /// </summary>
        /// <param name="game">Контекст игры</param>
        /// <param name="player">Игрок, владеющий картой</param>
        /// <param name="cardIndex">Номер проверяемой карты</param>
        /// <returns>Возможность сброса карты</returns>
        bool CanDiscardCard(Game game, Player player, int cardIndex);
    }
}
