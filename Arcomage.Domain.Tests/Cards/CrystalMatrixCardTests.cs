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
    public class CrystalMatrixCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            CrystalMatrixCard sut)
        {
            sut.Activate(game);

            Assert.Equal(3, game.FirstPlayer.Resources.Magic);
            Assert.Equal(23, game.FirstPlayer.Buildings.Tower);
            Assert.Equal(21, game.SecondPlayer.Buildings.Tower);
        }
    }
}
