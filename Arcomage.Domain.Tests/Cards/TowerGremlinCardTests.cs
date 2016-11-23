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
    public class TowerGremlinCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            TowerGremlinCard sut)
        {
            sut.Activate(game);

            Assert.Equal(22, game.FirstPlayer.Buildings.Tower);
            Assert.Equal(9, game.FirstPlayer.Buildings.Wall);
            Assert.Equal(3, game.SecondPlayer.Buildings.Wall);
        }
    }
}
