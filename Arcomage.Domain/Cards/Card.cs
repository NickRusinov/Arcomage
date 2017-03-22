using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain.Internal;
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
        /// Порядковый номер карты, извлеченной из колоды
        /// </summary>
        public int Index { get; private set; }

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
        
        /// <summary>
        /// Создает копию карту с указанным порядковым номером
        /// </summary>
        /// <param name="index">Порядковый номер новой карты</param>
        /// <returns>Новая карта с указанным порядковым номером</returns>
        public virtual Card WithIndex(int index)
        {
            var card = FrameworkExtensions.Copy(this);
            card.Index = index;

            return card;
        }
    }
}
