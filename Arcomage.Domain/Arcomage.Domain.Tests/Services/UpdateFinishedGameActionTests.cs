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
            [Frozen] Mock<Rule> gameConditionMock,
            UpdateFinishedGameAction sut)
        {
            gameConditionMock.Setup(gc => gc.IsWin(game)).Returns<WinResult>(null);

            sut.Execute(game, 1);

            Assert.False(game.IsFinished);
        }

        [Theory, AutoFixture]
        public void SetFinishedToTrueTest(
            [Frozen] Game game,
            [Frozen] Mock<Rule> gameConditionMock,
            UpdateFinishedGameAction sut)
        {
            gameConditionMock.Setup(gc => gc.IsWin(game)).Returns(new WinResult());

            sut.Execute(game, 1);

            Assert.True(game.IsFinished);
        }

        [Theory, AutoFixture]
        public void OnNotFinishedGameActionCalledTest(
            [Frozen] Game game,
            [Frozen] Mock<Rule> gameConditionMock,
            Mock<IGameAction> onFinishedGameActionMock,
            Mock<IGameAction> onNotFinishedGameActionMock)
        {
            gameConditionMock.Setup(gc => gc.IsWin(game)).Returns<WinResult>(null);
            var sut = new UpdateFinishedGameAction(gameConditionMock.Object, onFinishedGameActionMock.Object, onNotFinishedGameActionMock.Object);

            sut.Execute(game, 1);

            onNotFinishedGameActionMock.Verify(ga => ga.Execute(game, 1), Times.Once);
            onFinishedGameActionMock.Verify(ga => ga.Execute(game, 1), Times.Never);
        }

        [Theory, AutoFixture]
        public void OnFinishedGameActionCalledTest(
            [Frozen] Game game,
            [Frozen] Mock<Rule> gameConditionMock,
            Mock<IGameAction> onFinishedGameActionMock,
            Mock<IGameAction> onNotFinishedGameActionMock)
        {
            gameConditionMock.Setup(gc => gc.IsWin(game)).Returns(new WinResult());
            var sut = new UpdateFinishedGameAction(gameConditionMock.Object, onFinishedGameActionMock.Object, onNotFinishedGameActionMock.Object);

            sut.Execute(game, 1);

            onNotFinishedGameActionMock.Verify(ga => ga.Execute(game, 1), Times.Never);
            onFinishedGameActionMock.Verify(ga => ga.Execute(game, 1), Times.Once);
        }
    }
}
