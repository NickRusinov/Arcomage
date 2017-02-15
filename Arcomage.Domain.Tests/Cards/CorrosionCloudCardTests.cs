using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class CorrosionCloudCardTests
    {
        [Theory, AutoFixture]
        public void ActivateWhenWallNotZeroTest(Game game,
            CorrosionCloudCard sut)
        {
            sut.Activate(game);

            Assert.Equal(0, game.Players.SecondPlayer.Buildings.Wall);
            Assert.Equal(15, game.Players.SecondPlayer.Buildings.Tower);
        }

        [Theory, AutoFixture]
        public void ActivateWhenWallZeroTest(Game game,
            CorrosionCloudCard sut)
        {
            game.Players.SecondPlayer.Buildings.Wall = 0;

            sut.Activate(game);
            
            Assert.Equal(13, game.Players.SecondPlayer.Buildings.Tower);
        }
    }
}
