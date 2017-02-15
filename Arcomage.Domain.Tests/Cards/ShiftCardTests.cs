using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class ShiftCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            ShiftCard sut)
        {
            game.Players.FirstPlayer.Buildings.Wall = 12;

            sut.Activate(game);

            Assert.Equal(5, game.Players.FirstPlayer.Buildings.Wall);
            Assert.Equal(12, game.Players.SecondPlayer.Buildings.Wall);
        }
    }
}
