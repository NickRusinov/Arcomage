using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class LightningShardCardTests
    {
        [Theory, AutoFixture]
        public void ActivateWhenNoLessTowerTest(Game game,
            LightningShardCard sut)
        {
            sut.Activate(game);

            Assert.Equal(12, game.Players.SecondPlayer.Buildings.Tower);
        }

        [Theory, AutoFixture]
        public void ActivateWhenLessTowerTest(Game game,
            LightningShardCard sut)
        {
            game.Players.SecondPlayer.Buildings.Wall = 20;

            sut.Activate(game);

            Assert.Equal(17, game.Players.FirstPlayer.Buildings.Tower);
            Assert.Equal(0, game.Players.FirstPlayer.Buildings.Wall);
            Assert.Equal(12, game.Players.SecondPlayer.Buildings.Wall);
        }
    }
}
