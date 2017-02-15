using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class CrystallizeCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            CrystallizeCard sut)
        {
            sut.Activate(game);

            Assert.Equal(31, game.Players.FirstPlayer.Buildings.Tower);
            Assert.Equal(0, game.Players.FirstPlayer.Buildings.Wall);
        }
    }
}
