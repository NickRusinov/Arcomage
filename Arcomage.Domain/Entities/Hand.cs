using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Domain.Entities
{
    [Serializable]
    public class Hand
    {
        public Hand(IList<Card> cards)
        {
            Cards = cards;
        }

        public IList<Card> Cards { get; }
    }
}
