using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class HarmonicVibeCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            HarmonicVibeCard sut)
        {
            sut.Activate(game);

            Assert.Equal(23, game.Players.FirstPlayer.Buildings.Tower);
            Assert.Equal(8, game.Players.FirstPlayer.Buildings.Wall);
            Assert.Equal(3, game.Players.FirstPlayer.Resources.Magic);
        }
    }
}
