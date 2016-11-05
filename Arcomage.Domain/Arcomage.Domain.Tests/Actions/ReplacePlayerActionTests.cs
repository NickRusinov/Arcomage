using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Actions;
using Arcomage.Domain.Entities;
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
            game.PlayAgainTurns = 0;

            sut.PlayExecute(game, game.FirstPlayer, 1);
            
            Assert.Equal(PlayerMode.SecondPlayer, game.PlayerMode);
        }

        [Theory, AutoFixture]
        public void ReplacePlayerWhenPlayAgainTest(
            [Frozen] Game game,
            ReplacePlayerAction sut)
        {
            game.PlayAgainTurns = 1;

            sut.PlayExecute(game, game.FirstPlayer, 1);
            
            Assert.Equal(PlayerMode.FirstPlayer, game.PlayerMode);
        }
    }
}
