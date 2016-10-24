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
    public class ActivateCardGameActionTests
    {
        [Theory, AutoFixture]
        public void ActivateCalledTest(
            [Frozen] Mock<Card> cardMock,
            [Frozen] Game game,
            ActivateCardGameAction sut)
        {
            cardMock.Setup(c => c.IsEnoughResources(It.IsAny<Resources>())).Returns(true);

            sut.Execute(game, 1);

            cardMock.Verify(c => c.Activate(It.IsAny<Game>()), Times.Once);
        }

        [Theory, AutoFixture]
        public void PaymentResourcesCalledTest(
            [Frozen] Mock<Card> cardMock,
            [Frozen] Game game,
            ActivateCardGameAction sut)
        {
            cardMock.Setup(c => c.IsEnoughResources(It.IsAny<Resources>())).Returns(true);

            sut.Execute(game, 1);

            cardMock.Verify(c => c.PaymentResources(It.IsAny<Resources>()), Times.Once);
        }
    }
}
