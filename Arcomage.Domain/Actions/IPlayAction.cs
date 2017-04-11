using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Players;

namespace Arcomage.Domain.Actions
{
    /// <summary>
    /// Игровая логика, выполняемая после совершения хода игроком
    /// </summary>
    public interface IPlayAction
    {
        /// <summary>
        /// Выполянет действия после совершения хода игроком
        /// </summary>
        /// <param name="game">Контекст игры</param>
        /// <param name="playResult">Ход игрока</param>
        Task<GameResult> Play(Game game, Player player, PlayResult playResult);

        bool CanPlay(Game game, Player player, PlayResult playResult);
    }
}
