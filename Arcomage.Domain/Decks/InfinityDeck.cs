using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Decks
{
    public class InfinityDeck : Deck
    {
        private readonly Random random;

        private readonly List<Card> cardCollection;

        public InfinityDeck(Random random, ICollection<Card> cardCollection)
        {
            this.random = random;
            this.cardCollection = new List<Card>(cardCollection);
        }

        public override Card PopCard(Game game)
        {
            var randomCardIndex = random.Next(cardCollection.Count);

            return cardCollection[randomCardIndex];
        }

        public override void PushCard(Game game, Card card)
        {

        }
    }
}
