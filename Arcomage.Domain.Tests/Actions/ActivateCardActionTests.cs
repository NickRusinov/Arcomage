using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Actions;
using Arcomage.Domain.Cards;
using Moq;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace Arcomage.Domain.Tests.Actions
{
    public class ActivateCardActionTests
    {
        [Theory, AutoFixture]
        public void ActivateCalledTest(
            [Frozen] Mock<Card> cardMock,
            [Frozen] Game game,
            ActivateCardAction sut)
        {
            sut.Play(game, new PlayResult(1, true));

            cardMock.Verify(c => c.Activate(game), Times.Once);
        }

        [Theory, AutoFixture]
        public void ActivateNotCalledTest(
            [Frozen] Mock<Card> cardMock,
            [Frozen] Game game,
            ActivateCardAction sut)
        {
            sut.Play(game, new PlayResult(1, false));

            cardMock.Verify(c => c.Activate(game), Times.Never);
        }

        [Theory, AutoFixture]
        public void ResourcePriceDecreaseCalledTest(
            [Frozen] Mock<Card> cardMock,
            [Frozen] Game game,
            ActivateCardAction sut)
        {
            cardMock.SetupGet(c => c.Price).Returns(4);

            sut.Play(game, new PlayResult(1, true));

            Assert.Equal(1, game.Players.FirstPlayer.Resources.Bricks);
        }

        [Theory, AutoFixture]
        public void ResourcePriceNotDescreaseTest(
            [Frozen] Mock<Card> cardMock,
            [Frozen] Game game,
            ActivateCardAction sut)
        {
            sut.Play(game, new PlayResult(1, false));

            Assert.Equal(5, game.Players.FirstPlayer.Resources.Bricks);
        }
    }
}
