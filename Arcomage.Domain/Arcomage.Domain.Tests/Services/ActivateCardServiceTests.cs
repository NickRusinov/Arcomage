﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Exceptions;
using Arcomage.Domain.Services;
using Moq;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace Arcomage.Domain.Tests.Services
{
    public class ActivateCardServiceTests
    {
        [Theory, AutoFixture]
        public void ActivateCalledTest(
            [Frozen] Mock<Card> cardMock,
            ActivateCardService sut)
        {
            cardMock.Setup(c => c.IsEnoughResources(It.IsAny<Resources>())).Returns(true);

            sut.ActivateCard(1);

            cardMock.Verify(c => c.Activate(It.IsAny<Game>()), Times.Once);
        }

        [Theory, AutoFixture]
        public void PaymentResourcesCalledTest(
            [Frozen] Mock<Card> cardMock,
            ActivateCardService sut)
        {
            cardMock.Setup(c => c.IsEnoughResources(It.IsAny<Resources>())).Returns(true);

            sut.ActivateCard(1);

            cardMock.Verify(c => c.PaymentResources(It.IsAny<Resources>()), Times.Once);
        }

        [Theory, AutoFixture]
        public void ThrowsNotEnoughResourcesExceptionTest(
            [Frozen] Mock<Card> cardMock,
            ActivateCardService sut)
        {
            cardMock.Setup(c => c.IsEnoughResources(It.IsAny<Resources>())).Returns(false);

            Assert.Throws<NotEnoughResourcesException>(() => sut.ActivateCard(1));
        }
    }
}
