using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain.Resources;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Класс, представляющий описание игровой карты
    /// </summary>
    [Serializable]
    public abstract class Card
    {
        /// <summary>
        /// Цена карты
        /// </summary>
        public abstract int Price { get; }

        /// <summary>
        /// Тип игрового ресурса карты
        /// </summary>
        public abstract ResourceKind Kind { get; }

        /// <summary>
        /// Выполняет действия, представленные в описании карты
        /// </summary>
        /// <param name="game">Контекст игры</param>
        public abstract void Activate(Game game);
    }
}
