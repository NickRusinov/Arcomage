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
    public class SpizzerCardTests
    {
        [Theory, AutoFixture]
        public void ActivateWhenWallZeroTest(Game game,
            SpizzerCard sut)
        {
            game.SecondPlayer.Buildings.Wall = 0;

            sut.Activate(game);

            Assert.Equal(10, game.SecondPlayer.Buildings.Tower);
        }

        [Theory, AutoFixture]
        public void ActivateWhenWallNotZeroTest(Game game,
            SpizzerCard sut)
        {
            sut.Activate(game);

            Assert.Equal(0, game.SecondPlayer.Buildings.Wall);
            Assert.Equal(19, game.SecondPlayer.Buildings.Tower);
        }
    }
}
