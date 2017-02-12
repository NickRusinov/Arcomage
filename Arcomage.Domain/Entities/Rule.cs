using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Domain.Entities
{
    /// <summary>
    /// Класс, описывающий правила игры
    /// </summary>
    [Serializable]
    public abstract class Rule
    {
        /// <summary>
        /// Создает начальные значения строений игрока
        /// </summary>
        /// <returns>Строения игрока в начале игры</returns>
        public abstract Buildings CreateBuildings();

        /// <summary>
        /// Создает начальные значения ресурсов игрока
        /// </summary>
        /// <returns>Ресурсы игрока в начале игры</returns>
        public abstract Resources CreateResources();

        /// <summary>
        /// Определяет окончание и победителя игры, если она завершена
        /// </summary>
        /// <param name="game">Контекст игры</param>
        /// <returns>Результат игры на текущий ход</returns>
        public abstract GameResult IsWin(Game game);
    }
}
