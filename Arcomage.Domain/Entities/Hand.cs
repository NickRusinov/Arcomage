using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Domain.Entities
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
