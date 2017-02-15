using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Actions;
using Arcomage.Domain.Players;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace Arcomage.Domain.Tests.Actions
{
    public class ReplacePlayerActionTests
    {
        [Theory, AutoFixture]
        public void ReplacePlayerTest(
            [Frozen] Game game,
            ReplacePlayerAction sut)
        {
            game.PlayAgain = 0;

            sut.Play(game, new PlayResult(1, true));
            
            Assert.Equal(PlayerKind.Second, game.Players.Kind);
        }

        [Theory, AutoFixture]
        public void ReplacePlayerWhenPlayAgainTest(
            [Frozen] Game game,
            ReplacePlayerAction sut)
        {
            game.PlayAgain = 1;

            sut.Play(game, new PlayResult(1, true));
            
            Assert.Equal(PlayerKind.First, game.Players.Kind);
        }
    }
}
