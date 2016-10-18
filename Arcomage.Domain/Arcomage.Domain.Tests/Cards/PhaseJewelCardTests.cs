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
    public class PhaseJewelCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            PhaseJewelCard sut)
        {
            sut.Activate(game);

            Assert.Equal(33, game.FirstPlayer.Buildings.Tower);
            Assert.Equal(11, game.FirstPlayer.Resources.Bricks);
            Assert.Equal(11, game.FirstPlayer.Resources.Recruits);
        }
    }
}
