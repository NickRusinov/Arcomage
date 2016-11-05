using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Actions;
using Arcomage.Domain.Entities;
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
            cardMock.Setup(c => c.IsEnoughResources(It.IsAny<Resources>())).Returns(true);

            sut.PlayExecute(game, game.FirstPlayer, 1);

            cardMock.Verify(c => c.Activate(It.IsAny<Game>()), Times.Once);
        }

        [Theory, AutoFixture]
        public void PaymentResourcesCalledTest(
            [Frozen] Mock<Card> cardMock,
            [Frozen] Game game,
            ActivateCardAction sut)
        {
            cardMock.Setup(c => c.IsEnoughResources(It.IsAny<Resources>())).Returns(true);

            sut.PlayExecute(game, game.FirstPlayer, 1);

            cardMock.Verify(c => c.PaymentResources(It.IsAny<Resources>()), Times.Once);
        }
    }
}
