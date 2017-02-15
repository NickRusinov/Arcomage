using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class PearlOfWisdomCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            PearlOfWisdomCard sut)
        {
            sut.Activate(game);

            Assert.Equal(25, game.Players.FirstPlayer.Buildings.Tower);
            Assert.Equal(3, game.Players.FirstPlayer.Resources.Magic);
        }
    }
}
