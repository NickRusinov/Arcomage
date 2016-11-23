using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Decks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Tests.Internal;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace Arcomage.Domain.Tests.Decks
{
    public class InfinityDeckTests
    {
        [Theory, AutoFixture]
        public void InfinityDeckTest(Game game,
            [Frozen] Random random,
            [Frozen] IReadOnlyCollection<Card> cardCollection,
            InfinityDeck sut)
        {
            var fakeRandom = (FakeRandom)random;

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
