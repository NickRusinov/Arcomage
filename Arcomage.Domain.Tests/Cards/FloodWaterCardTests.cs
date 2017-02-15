using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
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

            Assert.Equal(2, game.Players.FirstPlayer.Resources.Dungeons);
            Assert.Equal(20, game.Players.FirstPlayer.Buildings.Tower);
            Assert.Equal(2, game.Players.SecondPlayer.Resources.Dungeons);
            Assert.Equal(20, game.Players.SecondPlayer.Buildings.Tower);
        }

        [Theory, AutoFixture]
        public void ActivateWhenNoLessWallTest(Game game,
            FloodWaterCard sut)
        {
            game.Players.FirstPlayer.Buildings.Wall = 7;

            sut.Activate(game);

            Assert.Equal(2, game.Players.FirstPlayer.Resources.Dungeons);
            Assert.Equal(20, game.Players.FirstPlayer.Buildings.Tower);
            Assert.Equal(1, game.Players.SecondPlayer.Resources.Dungeons);
            Assert.Equal(18, game.Players.SecondPlayer.Buildings.Tower);
        }

        [Theory, AutoFixture]
        public void ActivateWhenLessWallTest(Game game,
            FloodWaterCard sut)
        {
            game.Players.SecondPlayer.Buildings.Wall = 7;

            sut.Activate(game);

            Assert.Equal(1, game.Players.FirstPlayer.Resources.Dungeons);
            Assert.Equal(18, game.Players.FirstPlayer.Buildings.Tower);
            Assert.Equal(2, game.Players.SecondPlayer.Resources.Dungeons);
            Assert.Equal(20, game.Players.SecondPlayer.Buildings.Tower);
        }
    }
}
