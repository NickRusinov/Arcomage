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
    public class CrystalRocksCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            CrystalRocksCard sut)
        {
            sut.Activate(game);

            Assert.Equal(12, game.FirstPlayer.Buildings.Wall);
            Assert.Equal(12, game.FirstPlayer.Resources.Gems);
        }
    }
}
