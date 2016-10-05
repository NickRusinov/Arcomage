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
    public class PlayCardServiceTests
    {
        [Theory, AutoFixture]
        public void ActivateCardCalledTest(int cardIndex,
            [Frozen] Mock<IActivateCardService> activateCardServiceMock,
            PlayCardService sut)
        {
            sut.PlayCard(cardIndex);

            activateCardServiceMock.Verify(acs => acs.ActivateCard(cardIndex), Times.Once);
        }

        [Theory, AutoFixture]
        public void ReplaceCardCalledTest(int cardIndex,
            [Frozen] Mock<IReplaceCardService> replaceCardServiceMock,
            PlayCardService sut)
        {
            sut.PlayCard(cardIndex);

            replaceCardServiceMock.Verify(rcs => rcs.ReplaceCard(cardIndex), Times.Once);
        }

        [Theory, AutoFixture]
        public void ReplacePlayerCalledTest(int cardIndex,
            [Frozen] Mock<IReplacePlayerService> replacePlayerServiceMock,
            PlayCardService sut)
        {
            sut.PlayCard(cardIndex);

            replacePlayerServiceMock.Verify(rps => rps.ReplacePlayer(), Times.Once);
        }
    }
}
