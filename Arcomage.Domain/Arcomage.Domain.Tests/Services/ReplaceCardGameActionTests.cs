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
            [Frozen] Mock<CardDeck> cardDeckMock,
            [Frozen] Game game,
            ReplaceCardGameAction sut)
        {
            var oldCard = game.FirstPlayer.CardSet.Cards[1];
            var newCard = Mock.Of<Card>();
            cardDeckMock.Setup(cd => cd.PopCard(It.IsAny<Game>())).Returns(newCard);

            sut.Execute(game, 1);

            cardDeckMock.Verify(cd => cd.PopCard(It.IsAny<Game>()), Times.Once);
            cardDeckMock.Verify(cd => cd.PushCard(It.IsAny<Game>(), oldCard), Times.Once);
            Assert.Equal(newCard, game.FirstPlayer.CardSet.Cards[1]);
        }
    }
}
