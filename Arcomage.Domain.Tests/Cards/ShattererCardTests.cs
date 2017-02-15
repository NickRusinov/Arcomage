using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class ShattererCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            ShattererCard sut)
        {
            sut.Activate(game);

            Assert.Equal(11, game.Players.SecondPlayer.Buildings.Tower);
            Assert.Equal(1, game.Players.FirstPlayer.Resources.Magic);
        }
    }
}
