using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Domain.Entities
{
    public class History
    {
        public History(IList<Card> cards)
        {
            Cards = cards;
        }

        public IList<Card> Cards { get; }
    }
}
