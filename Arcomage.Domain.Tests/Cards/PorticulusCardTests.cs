using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class PorticulusCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            PorticulusCard sut)
        {
            sut.Activate(game);

            Assert.Equal(10, game.Players.FirstPlayer.Buildings.Wall);
            Assert.Equal(3, game.Players.FirstPlayer.Resources.Dungeons);
        }
    }
}
