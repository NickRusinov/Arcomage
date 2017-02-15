using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class PowerBurnCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            PowerBurnCard sut)
        {
            sut.Activate(game);

            Assert.Equal(15, game.Players.FirstPlayer.Buildings.Tower);
            Assert.Equal(4, game.Players.FirstPlayer.Resources.Magic);
        }
    }
}
