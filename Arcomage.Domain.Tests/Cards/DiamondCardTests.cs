using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class DiamondCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            DiamondCard sut)
        {
            sut.Activate(game);

            Assert.Equal(35, game.Players.FirstPlayer.Buildings.Tower);
        }
    }
}
