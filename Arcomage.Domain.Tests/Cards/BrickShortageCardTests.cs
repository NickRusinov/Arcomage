using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class BrickShortageCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            BrickShortageCard sut)
        {
            sut.Activate(game);

            Assert.Equal(0, game.Players.FirstPlayer.Resources.Bricks);
            Assert.Equal(0, game.Players.SecondPlayer.Resources.Bricks);
        }
    }
}
