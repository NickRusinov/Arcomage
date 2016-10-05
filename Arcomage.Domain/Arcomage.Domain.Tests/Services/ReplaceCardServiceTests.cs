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
    public class ReplaceCardServiceTests
    {
        [Theory, AutoFixture]
        public void ReplaceCardTest(Mock<Card> cardMock,
            [Frozen] Player player,
            [Frozen] Mock<CardDeck> cardDeckMock,
            ReplaceCardService sut)
        {
            var oldCard = player.CardSet.Cards[1];
            var newCard = cardMock.Object;
            cardDeckMock.Setup(cd => cd.PopCard(It.IsAny<Game>())).Returns(newCard);

            sut.ReplaceCard(1);

            cardDeckMock.Verify(cd => cd.PopCard(It.IsAny<Game>()), Times.Once);
            cardDeckMock.Verify(cd => cd.PushCard(It.IsAny<Game>(), oldCard), Times.Once);
            Assert.Equal(newCard, player.CardSet.Cards[1]);
        }
    }
}
