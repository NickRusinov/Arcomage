using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class GreatWallCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            GreatWallCard sut)
        {
            sut.Activate(game);

            Assert.Equal(20, game.Players.FirstPlayer.Buildings.Wall);
        }
    }
}
