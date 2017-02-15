using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class DwarvesCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            DwarvesCard sut)
        {
            sut.Activate(game);

            Assert.Equal(1, game.Players.SecondPlayer.Buildings.Wall);
            Assert.Equal(8, game.Players.FirstPlayer.Buildings.Wall);
        }
    }
}
