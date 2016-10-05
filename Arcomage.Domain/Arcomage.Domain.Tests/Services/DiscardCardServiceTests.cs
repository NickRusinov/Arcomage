using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Services;
using Moq;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace Arcomage.Domain.Tests.Services
{
    public class DiscardCardServiceTests
    {
        [Theory, AutoFixture]
        public void ReplaceCardCalledTest(int cardIndex,
            [Frozen] Mock<IReplaceCardService> replaceCardServiceMock,
            DiscardCardService sut)
        {
            sut.DiscardCard(cardIndex);

            replaceCardServiceMock.Verify(rcs => rcs.ReplaceCard(cardIndex), Times.Once);
        }

        [Theory, AutoFixture]
        public void ReplacePlayerCalledTest(int cardIndex,
            [Frozen] Mock<IReplacePlayerService> replacePlayerServiceMock,
            DiscardCardService sut)
        {
            sut.DiscardCard(cardIndex);

            replacePlayerServiceMock.Verify(rps => rps.ReplacePlayer(), Times.Once);
        }
    }
}
