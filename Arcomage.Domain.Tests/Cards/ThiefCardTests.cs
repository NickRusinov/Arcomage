using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Arcomage.Domain.Entities;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class ThiefCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            ThiefCard sut)
        {
            sut.Activate(game);

            Assert.Equal(0, game.SecondPlayer.Resources.Bricks);
            Assert.Equal(0, game.SecondPlayer.Resources.Gems);
            Assert.Equal(7, game.FirstPlayer.Resources.Bricks);
            Assert.Equal(7, game.FirstPlayer.Resources.Gems);
        }
    }
}
