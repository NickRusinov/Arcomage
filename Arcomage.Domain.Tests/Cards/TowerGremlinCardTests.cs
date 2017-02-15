using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class TowerGremlinCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            TowerGremlinCard sut)
        {
            sut.Activate(game);

            Assert.Equal(22, game.Players.FirstPlayer.Buildings.Tower);
            Assert.Equal(9, game.Players.FirstPlayer.Buildings.Wall);
            Assert.Equal(3, game.Players.SecondPlayer.Buildings.Wall);
        }
    }
}
