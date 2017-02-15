using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class ReinforcedWallCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            ReinforcedWallCard sut)
        {
            sut.Activate(game);

            Assert.Equal(13, game.Players.FirstPlayer.Buildings.Wall);
        }
    }
}
