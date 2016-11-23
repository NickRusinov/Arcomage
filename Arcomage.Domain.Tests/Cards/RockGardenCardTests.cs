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
    public class RockGardenCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            RockGardenCard sut)
        {
            sut.Activate(game);

            Assert.Equal(6, game.FirstPlayer.Buildings.Wall);
            Assert.Equal(21, game.FirstPlayer.Buildings.Tower);
            Assert.Equal(7, game.FirstPlayer.Resources.Recruits);
        }
    }
}
