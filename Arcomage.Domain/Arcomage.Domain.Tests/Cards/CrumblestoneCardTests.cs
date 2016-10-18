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
    public class CrumblestoneCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            CrumblestoneCard sut)
        {
            sut.Activate(game);

            Assert.Equal(25, game.FirstPlayer.Buildings.Tower);
            Assert.Equal(0, game.SecondPlayer.Resources.Bricks);
        }
    }
}
