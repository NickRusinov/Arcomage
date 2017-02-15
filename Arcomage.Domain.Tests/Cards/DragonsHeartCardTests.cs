using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class DragonsHeartCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            DragonsHeartCard sut)
        {
            sut.Activate(game);

            Assert.Equal(25, game.Players.FirstPlayer.Buildings.Wall);
            Assert.Equal(28, game.Players.FirstPlayer.Buildings.Tower);
        }
    }
}
