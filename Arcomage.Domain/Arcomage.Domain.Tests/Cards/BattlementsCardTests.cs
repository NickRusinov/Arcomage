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
    public class BattlementsCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            BattlementsCard sut)
        {
            sut.Activate(game);

            Assert.Equal(12, game.FirstPlayer.Buildings.Wall);
            Assert.Equal(0, game.SecondPlayer.Buildings.Wall);
            Assert.Equal(19, game.SecondPlayer.Buildings.Tower);
        }
    }
}
