using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Actions;
using Arcomage.Domain.Cards;
using Arcomage.Domain.Decks;
using Moq;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace Arcomage.Domain.Tests.Actions
{
    public class ReplaceCardActionTests
    {
        [Theory, AutoFixture]
        public void ReplaceCardTest(
            [Frozen] Mock<Deck> deckMock,
            [Frozen] Game game,
            ReplaceCardAction sut)
        {
            var oldCard = game.Players.FirstPlayer.Hand.Cards[1];
            var newCard = Mock.Of<Card>();
            deckMock.Setup(cd => cd.PopCard(It.IsAny<Game>())).Returns(newCard);

            sut.Play(game, new PlayResult(1, true));

            deckMock.Verify(cd => cd.PopCard(It.IsAny<Game>()), Times.Once);
            deckMock.Verify(cd => cd.PushCard(It.IsAny<Game>(), oldCard), Times.Once);
            Assert.Equal(newCard, game.Players.FirstPlayer.Hand.Cards[1]);
        }
    }
}
