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
    }
}
