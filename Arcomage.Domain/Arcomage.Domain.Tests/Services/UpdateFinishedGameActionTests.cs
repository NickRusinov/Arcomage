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
    public class UpdateFinishedGameActionTests
    {
        [Theory, AutoFixture]
        public void SetFinishedToFalseTest(
            [Frozen] Game game,
            [Frozen] Mock<GameCondition> gameConditionMock,
            UpdateFinishedGameAction sut)
        {
            gameConditionMock.Setup(gc => gc.IsWin(It.IsAny<Game>())).Returns<WinResult>(null);

            sut.Execute(1);

            Assert.False(game.IsFinished);
        }

        [Theory, AutoFixture]
        public void SetFinishedToTrueTest(
            [Frozen] Game game,
            [Frozen] Mock<GameCondition> gameConditionMock,
            UpdateFinishedGameAction sut)
        {
            gameConditionMock.Setup(gc => gc.IsWin(It.IsAny<Game>())).Returns(new WinResult());

            sut.Execute(1);

            Assert.True(game.IsFinished);
        }
    }
}
