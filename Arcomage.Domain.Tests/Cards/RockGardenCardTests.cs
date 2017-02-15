using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class RockGardenCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            RockGardenCard sut)
        {
            sut.Activate(game);

            Assert.Equal(6, game.Players.FirstPlayer.Buildings.Wall);
            Assert.Equal(21, game.Players.FirstPlayer.Buildings.Tower);
            Assert.Equal(7, game.Players.FirstPlayer.Resources.Recruits);
        }
    }
}
