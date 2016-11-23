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
    public class SpearmanCardTests
    {
        [Theory, AutoFixture]
        public void ActivateWhenMoreWallTest(Game game,
            SpearmanCard sut)
        {
            game.FirstPlayer.Buildings.Wall = 6;

            sut.Activate(game);

            Assert.Equal(2, game.SecondPlayer.Buildings.Wall);
        }

        [Theory, AutoFixture]
        public void ActivateWhenNoMoreWallTest(Game game,
            SpearmanCard sut)
        {
            sut.Activate(game);

            Assert.Equal(3, game.SecondPlayer.Buildings.Wall);
        }
    }
}
