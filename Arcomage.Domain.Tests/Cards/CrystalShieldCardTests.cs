using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class CrystalShieldCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            CrystalShieldCard sut)
        {
            sut.Activate(game);

            Assert.Equal(28, game.Players.FirstPlayer.Buildings.Tower);
            Assert.Equal(8, game.Players.FirstPlayer.Buildings.Wall);
        }
    }
}
