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
    public class ShiftCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            ShiftCard sut)
        {
            game.FirstPlayer.Buildings.Wall = 12;

            sut.Activate(game);

            Assert.Equal(5, game.FirstPlayer.Buildings.Wall);
            Assert.Equal(12, game.SecondPlayer.Buildings.Wall);
        }
    }
}
