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
    public class UpdateFinishedActionTests
    {
        [Theory, AutoFixture]
        public void SetFinishedToFalseTest(
            [Frozen] Game game,
            [Frozen] Mock<Rule> gameConditionMock,
            UpdateFinishedAction sut)
        {
            gameConditionMock.Setup(gc => gc.IsWin(game)).Returns(GameResult.None);

            sut.PlayExecute(game, game.FirstPlayer, 1);

            Assert.Equal(GameResult.None, game.Result);
        }

        [Theory, AutoFixture]
        public void SetFinishedToTrueTest(
            [Frozen] Game game,
            [Frozen] Mock<Rule> gameConditionMock,
            UpdateFinishedAction sut)
        {
            gameConditionMock.Setup(gc => gc.IsWin(game)).Returns(new GameResult(game.FirstPlayer, true));

            sut.PlayExecute(game, game.FirstPlayer, 1);

            Assert.Equal(game.FirstPlayer, game.Result.Player);
            Assert.True(game.Result.IsTowerBuild);
        }
    }
}
