using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Domain.Entities
{
    [Serializable]
    public class History
    {
        public History(IList<HistoryCard> cards)
        {
            Cards = cards;
        }

        public IList<HistoryCard> Cards { get; }
    }
}
