using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.CardDecks
{
    public class ClassicCardDeck : CardDeck
    {
        private readonly Random random;

        private readonly List<Card> cardCollection;

        public ClassicCardDeck(Random random, IReadOnlyCollection<Card> cardCollection)
        {
            this.random = random;
            this.cardCollection = new List<Card>(cardCollection);
        }

        public override Card PopCard(Game game)
        {
            var randomCardIndex = random.Next(cardCollection.Count / 2);

            var card = cardCollection[randomCardIndex];
            cardCollection.RemoveAt(randomCardIndex);

            return card;
        }

        public override void PushCard(Game game, Card card)
        {
            cardCollection.Add(card);
        }
    }
}
