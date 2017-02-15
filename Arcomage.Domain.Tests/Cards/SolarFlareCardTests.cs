using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
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

            Assert.Equal(22, game.Players.FirstPlayer.Buildings.Tower);
            Assert.Equal(18, game.Players.SecondPlayer.Buildings.Tower);
        }
    }
}
