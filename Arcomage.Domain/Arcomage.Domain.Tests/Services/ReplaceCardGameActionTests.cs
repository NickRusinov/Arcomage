using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Services;
using Moq;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace Arcomage.Domain.Tests.Services
{
    public class ReplaceCardGameActionTests
    {
        [Theory, AutoFixture]
        public void ReplaceCardTest(
            [Frozen] Mock<Deck> deckMock,
            [Frozen] Game game,
            ReplaceCardGameAction sut)
        {
            var oldCard = game.FirstPlayer.Hand.Cards[1];
            var newCard = Mock.Of<Card>();
            deckMock.Setup(cd => cd.PopCard(It.IsAny<Game>())).Returns(newCard);

            sut.Execute(game, 1);

            deckMock.Verify(cd => cd.PopCard(It.IsAny<Game>()), Times.Once);
            deckMock.Verify(cd => cd.PushCard(It.IsAny<Game>(), oldCard), Times.Once);
            Assert.Equal(newCard, game.FirstPlayer.Hand.Cards[1]);
        }
    }
}
