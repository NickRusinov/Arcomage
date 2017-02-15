using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class RockLauncherCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            RockLauncherCard sut)
        {
            sut.Activate(game);

            Assert.Equal(11, game.Players.FirstPlayer.Buildings.Wall);
            Assert.Equal(0, game.Players.SecondPlayer.Buildings.Wall);
            Assert.Equal(15, game.Players.SecondPlayer.Buildings.Tower);
        }
    }
}
