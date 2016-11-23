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
    public class FloodWaterCardTests
    {
        [Theory, AutoFixture]
        public void ActivateWhenEqualWallTest(Game game,
            FloodWaterCard sut)
        {
            sut.Activate(game);

            Assert.Equal(2, game.FirstPlayer.Resources.Dungeons);
            Assert.Equal(20, game.FirstPlayer.Buildings.Tower);
            Assert.Equal(2, game.SecondPlayer.Resources.Dungeons);
            Assert.Equal(20, game.SecondPlayer.Buildings.Tower);
        }

        [Theory, AutoFixture]
        public void ActivateWhenNoLessWallTest(Game game,
            FloodWaterCard sut)
        {
            game.FirstPlayer.Buildings.Wall = 7;

            sut.Activate(game);

            Assert.Equal(2, game.FirstPlayer.Resources.Dungeons);
            Assert.Equal(20, game.FirstPlayer.Buildings.Tower);
            Assert.Equal(1, game.SecondPlayer.Resources.Dungeons);
            Assert.Equal(18, game.SecondPlayer.Buildings.Tower);
        }

        [Theory, AutoFixture]
        public void ActivateWhenLessWallTest(Game game,
            FloodWaterCard sut)
        {
            game.SecondPlayer.Buildings.Wall = 7;

            sut.Activate(game);

            Assert.Equal(1, game.FirstPlayer.Resources.Dungeons);
            Assert.Equal(18, game.FirstPlayer.Buildings.Tower);
            Assert.Equal(2, game.SecondPlayer.Resources.Dungeons);
            Assert.Equal(20, game.SecondPlayer.Buildings.Tower);
        }
    }
}
