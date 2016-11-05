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
    public class FaerieCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            FaerieCard sut)
        {
            sut.Activate(game);

            Assert.Equal(3, game.SecondPlayer.Buildings.Wall);
            Assert.Equal(1, game.PlayAgain);
        }
    }
}
