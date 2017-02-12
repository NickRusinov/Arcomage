using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Domain.Entities
{
    /// <summary>
    /// Класс, описывающий игровую колоду
    /// </summary>
    [Serializable]
    public abstract class Deck
    {
        /// <summary>
        /// Извлекает карту из колоды
        /// </summary>
        /// <param name="game">Контекст игры</param>
        /// <returns>Извлеченная карта</returns>
        public abstract Card PopCard(Game game);

        /// <summary>
        /// Помещает карту в колоду
        /// </summary>
        /// <param name="game">Контекст игры</param>
        /// <param name="card">Игровая карта</param>
        public abstract void PushCard(Game game, Card card);
    }
}
