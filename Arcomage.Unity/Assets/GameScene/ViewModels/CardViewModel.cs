using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Cards;
using Arcomage.Domain.Resources;

namespace Arcomage.Unity.GameScene.ViewModels
{
    public class CardViewModel
    {
        // HACK
        public Card card;

        // HACK
        public CardViewModel(Card card)
        {
            this.card = card;
        }

        public string Identifier { get; set; }

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
            if (obj is CardViewModel)
                return Equals(card, ((CardViewModel)obj).card);

            if (obj is HistoryCardViewModel)
                return Equals(card, ((HistoryCardViewModel)obj).card);

            return false;
        }
    }
}
