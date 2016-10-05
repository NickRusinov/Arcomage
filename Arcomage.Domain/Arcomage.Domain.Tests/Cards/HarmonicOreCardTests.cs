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
    public class HarmonicOreCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            HarmonicOreCard sut)
        {
            sut.Activate(game);

            Assert.Equal(11, game.FirstPlayer.Buildings.Wall);
            Assert.Equal(23, game.FirstPlayer.Buildings.Tower);
        }
    }
}
