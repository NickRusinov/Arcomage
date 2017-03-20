using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Cards;
using Arcomage.Domain.Resources;

namespace Arcomage.Unity.GameScene.ViewModels
{
    public class HistoryCardViewModel
    {
        // HACK
        public Card card;

        // HACK
        public HistoryCardViewModel(Card card)
        {
            this.card = card;
        }

        public string Identifier { get; set; }

        public bool IsPlayed { get; set; }

        public ResourceKind Kind { get; set; }

        public int Price { get; set; }

        // HACK
        public override int GetHashCode()
        {
            return card.GetHashCode();
        }

        // HACK
        public override bool Equals(object obj)
        {
            return Equals(card, ((HistoryCardViewModel)obj).card);
        }
    }
}
