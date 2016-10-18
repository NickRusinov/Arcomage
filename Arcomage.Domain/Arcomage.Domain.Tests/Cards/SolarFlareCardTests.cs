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
    public class SolarFlareCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            SolarFlareCard sut)
        {
            sut.Activate(game);

            Assert.Equal(22, game.FirstPlayer.Buildings.Tower);
            Assert.Equal(18, game.SecondPlayer.Buildings.Tower);
        }
    }
}
