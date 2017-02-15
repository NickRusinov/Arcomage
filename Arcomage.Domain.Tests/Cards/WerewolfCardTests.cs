using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class WerewolfCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            WerewolfCard sut)
        {
            sut.Activate(game);

            Assert.Equal(0, game.Players.SecondPlayer.Buildings.Wall);
            Assert.Equal(16, game.Players.SecondPlayer.Buildings.Tower);
        }
    }
}
