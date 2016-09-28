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
    public class DwarvenMinersCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            DwarvenMinersCard sut)
        {
            sut.Activate(game);

            Assert.Equal(9, game.FirstPlayer.Buildings.Wall);
            Assert.Equal(3, game.FirstPlayer.Resources.Quarry);
        }
    }
}
