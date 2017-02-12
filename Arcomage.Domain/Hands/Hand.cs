using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;

namespace Arcomage.Domain.Hands
{
    /// <summary>
    /// Описание карт в руке одного из игроков
    /// </summary>
    [Serializable]
    public class Hand
    {
        /// <summary>
        /// Инициализирует экземпляр класса <see cref="Hand"/>
        /// </summary>
        /// <param name="cards">Список карт на руках игрока</param>
        public Hand(ICollection<Card> cards)
        {
            Contract.Requires(cards != null);

            Cards = cards.ToList();
        }

        /// <summary>
        /// Список карт на руках игрока
        /// </summary>
        public IList<Card> Cards { get; }
    }
}
