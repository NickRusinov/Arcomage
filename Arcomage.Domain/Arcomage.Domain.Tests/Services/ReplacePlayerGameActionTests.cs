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
    public class ReplacePlayerGameActionTests
    {
        [Theory, AutoFixture]
        public void ReplacePlayerTest(
            [Frozen] Game game,
            ReplacePlayerGameAction sut)
        {
            game.PlayAgainTurns = 0;

            sut.Execute(game, 1);
            
            Assert.Equal(PlayerMode.SecondPlayer, game.PlayerMode);
        }

        [Theory, AutoFixture]
        public void ReplacePlayerWhenPlayAgainTest(
            [Frozen] Game game,
            ReplacePlayerGameAction sut)
        {
            game.PlayAgainTurns = 1;

            sut.Execute(game, 1);
            
            Assert.Equal(PlayerMode.FirstPlayer, game.PlayerMode);
        }

        [Theory, AutoFixture]
        public void OnReplacePlayerGameActionCalledTest(
            [Frozen] Game game,
            [Frozen] Mock<IGameAction> gameActionMock,
            ReplacePlayerGameAction sut)
        {
            game.PlayAgainTurns = 0;

            sut.Execute(game, 1);

            gameActionMock.Verify(ga => ga.Execute(game, 1), Times.Once);
        }

        [Theory, AutoFixture]
        public void OnReplacePlayerGameActionNotCalledTest(
            [Frozen] Game game,
            [Frozen] Mock<IGameAction> gameActionMock,
            ReplacePlayerGameAction sut)
        {
            game.PlayAgainTurns = 1;

            sut.Execute(game, 1);

            gameActionMock.Verify(ga => ga.Execute(game, 1), Times.Never);
        }
    }
}
