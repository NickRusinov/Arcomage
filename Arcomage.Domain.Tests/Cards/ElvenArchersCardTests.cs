using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class ElvenArchersCardTests
    {
        [Theory, AutoFixture]
        public void ActivateWhenMoreWallTest(Game game,
            ElvenArchersCard sut)
        {
            game.Players.FirstPlayer.Buildings.Wall = 6;

            sut.Activate(game);

            Assert.Equal(14, game.Players.SecondPlayer.Buildings.Tower);
        }

        [Theory, AutoFixture]
        public void ActivateWhenNoMoreWallTest(Game game,
            ElvenArchersCard sut)
        {
            sut.Activate(game);

            Assert.Equal(0, game.Players.SecondPlayer.Buildings.Wall);
            Assert.Equal(19, game.Players.SecondPlayer.Buildings.Tower);
        }
    }
}
