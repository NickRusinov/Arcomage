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
    public class RainbowCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            RainbowCard sut)
        {
            sut.Activate(game);

            Assert.Equal(21, game.FirstPlayer.Buildings.Tower);
            Assert.Equal(21, game.SecondPlayer.Buildings.Tower);
            Assert.Equal(8, game.FirstPlayer.Resources.Gems);
        }
    }
}
