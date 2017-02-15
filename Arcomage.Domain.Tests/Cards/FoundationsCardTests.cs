using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class FoundationsCardTests
    {
        [Theory, AutoFixture]
        public void ActivateWhenWallNoZeroTest(Game game,
            FoundationsCard sut)
        {
            sut.Activate(game);

            Assert.Equal(8, game.Players.FirstPlayer.Buildings.Wall);
        }

        [Theory, AutoFixture]
        public void ActivateWhenWallZeroTest(Game game,
            FoundationsCard sut)
        {
            game.Players.FirstPlayer.Buildings.Wall = 0;

            sut.Activate(game);

            Assert.Equal(6, game.Players.FirstPlayer.Buildings.Wall);
        }
    }
}
