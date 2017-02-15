using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
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

            Assert.Equal(3, game.Players.FirstPlayer.Resources.Magic);
            Assert.Equal(23, game.Players.FirstPlayer.Buildings.Tower);
            Assert.Equal(21, game.Players.SecondPlayer.Buildings.Tower);
        }
    }
}
