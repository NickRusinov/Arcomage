using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Domain.Actions
{
    /// <summary>
    /// Игровая логика, представляющая игровой цикл
    /// </summary>
    public interface IPlayAction
    {
        /// <summary>
        /// Выполняет действия игрового цикла
        /// </summary>
        /// <param name="game">Контекст игры</param>
        Task<GameResult> Play(Game game);
    }
}
