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
    public class CrystalShieldCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            CrystalShieldCard sut)
        {
            sut.Activate(game);

            Assert.Equal(28, game.FirstPlayer.Buildings.Tower);
            Assert.Equal(8, game.FirstPlayer.Buildings.Wall);
        }
    }
}
