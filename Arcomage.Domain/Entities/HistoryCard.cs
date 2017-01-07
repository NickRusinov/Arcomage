using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Domain.Entities
{
    [Serializable]
    public class HistoryCard
    {
        public HistoryCard(Card card, bool isPlayed)
        {
            Card = card;
            IsPlayed = isPlayed;
        }

        public Card Card { get; }

        public bool IsPlayed { get; }
    }
}
