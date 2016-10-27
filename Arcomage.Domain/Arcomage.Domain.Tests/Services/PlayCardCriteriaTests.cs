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
    public class PlayCardCriteriaTests
    {
        [Theory, AutoFixture]
        public void CanPlayCardTest(
            [Frozen] Mock<Card> cardMock,
            [Frozen] Game game,
            PlayCardCriteria sut)
        {
            cardMock.Setup(c => c.IsEnoughResources(It.IsAny<Resources>())).Returns(true);

            var canPlayCard = sut.CanPlayCard(game, 1);

            Assert.True(canPlayCard);
        }

        [Theory, AutoFixture]
        public void CanPlayCardWhenNotEnoughResourcesTest(
            [Frozen] Mock<Card> cardMock,
            [Frozen] Game game,
            PlayCardCriteria sut)
        {
            cardMock.Setup(c => c.IsEnoughResources(It.IsAny<Resources>())).Returns(false);

            var canPlayCard = sut.CanPlayCard(game, 1);

            Assert.False(canPlayCard);
        }
    }
}
