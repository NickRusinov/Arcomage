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
            [Frozen] Mock<GameCondition> gameConditionMock,
            [Frozen] Game game,
            UpdateFinishedGameAction sut)
        {
            gameConditionMock.Setup(gc => gc.IsWin(game)).Returns<WinResult>(null);

            sut.Execute(game, 1);

            Assert.False(game.IsFinished);
        }

        [Theory, AutoFixture]
        public void SetFinishedToTrueTest(
            [Frozen] Mock<GameCondition> gameConditionMock,
            [Frozen] Game game,
            UpdateFinishedGameAction sut)
        {
            gameConditionMock.Setup(gc => gc.IsWin(game)).Returns(new WinResult());

            sut.Execute(game, 1);

            Assert.True(game.IsFinished);
        }
    }
}
