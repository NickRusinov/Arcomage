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
    public class ClassicDeckTests
    {
        [Theory, AutoFixture]
        public void ClassicDeckTest(Game game,
            [Frozen] Random random,
            [Frozen] IReadOnlyCollection<Card> cardCollection,
            ClassicDeck sut)
        {
            var fakeRandom = (FakeRandom)random;

            sut.PushCard(game, cardCollection.ElementAt(2));
            sut.PushCard(game, cardCollection.ElementAt(1));
            sut.PushCard(game, cardCollection.ElementAt(0));

            fakeRandom.NextGenerate = 2;
            var card = sut.PopCard(game);
            Assert.Equal(cardCollection.ElementAt(2), card);

            fakeRandom.NextGenerate = 1;
            card = sut.PopCard(game);
            Assert.Equal(cardCollection.ElementAt(1), card);

            fakeRandom.NextGenerate = 1;
            card = sut.PopCard(game);
            Assert.Equal(cardCollection.ElementAt(2), card);
        }
    }
}
