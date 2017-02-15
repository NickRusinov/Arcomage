using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class RubyCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            RubyCard sut)
        {
            sut.Activate(game);

            Assert.Equal(25, game.Players.FirstPlayer.Buildings.Tower);
        }
    }
}
