using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Arcomage.Domain.Decks;
using Arcomage.Domain.Tests.Internal;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace Arcomage.Domain.Tests.Decks
{
    public class InfinityDeckTests
    {
        [Theory, AutoFixture]
        public void InfinityDeckTest(Game game,
            [Frozen] InfinityDeckInfo deckInfo,
            [Frozen] ICollection<Card> cardCollection,
            InfinityDeck sut)
        {
            var fakeRandom = (FakeRandom)deckInfo.Random;

            fakeRandom.NextGenerate = 1;
            var card = sut.PopCard(game);
            Assert.Equal(cardCollection.ElementAt(1), card);

            fakeRandom.NextGenerate = 2;
            card = sut.PopCard(game);
            Assert.Equal(cardCollection.ElementAt(2), card);

            fakeRandom.NextGenerate = 0;
            card = sut.PopCard(game);
            Assert.Equal(cardCollection.ElementAt(0), card);
        }
    }
}
