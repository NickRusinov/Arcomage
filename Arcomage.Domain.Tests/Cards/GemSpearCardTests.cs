using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class GemSpearCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            GemSpearCard sut)
        {
            sut.Activate(game);

            Assert.Equal(15, game.Players.SecondPlayer.Buildings.Tower);
        }
    }
}
