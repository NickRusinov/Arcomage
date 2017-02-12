using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Players;

namespace Arcomage.Domain.Services
{
    /// <summary>
    /// Критерий возможности активации карты
    /// </summary>
    public interface IPlayCardCriteria
    {
        /// <summary>
        /// Определяет возможность активации карты
        /// </summary>
        /// <param name="game">Контекст игры</param>
        /// <param name="player">Игрок, владеющий картой</param>
        /// <param name="cardIndex">Номер проверяемой карты</param>
        /// <returns>Возможность активации карты</returns>
        bool CanPlayCard(Game game, Player player, int cardIndex);
    }
}
