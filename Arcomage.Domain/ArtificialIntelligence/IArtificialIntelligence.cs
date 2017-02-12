using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Players;

namespace Arcomage.Domain.ArtificialIntelligence
{
    /// <summary>
    /// Алгоритм ИИ компьютерного игрока
    /// </summary>
    public interface IArtificialIntelligence
    {
        /// <summary>
        /// Выполянет ход компьютерного игрока. Находит лучший из возможных ходов
        /// </summary>
        /// <param name="game">Контекст игры</param>
        /// <param name="player">Игрок, для которого вычисляется лучший ход</param>
        /// <returns>Результат хода игрока</returns>
        Task<PlayResult> Execute(Game game, Player player);
    }
}
