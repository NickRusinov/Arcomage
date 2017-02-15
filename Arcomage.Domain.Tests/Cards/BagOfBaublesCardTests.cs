using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class BagOfBaublesCardTests
    {
        [Theory, AutoFixture]
        public void ActivateWhenNoLessTowerTest(Game game,
            BagOfBaublesCard sut)
        {
            sut.Activate(game);

            Assert.Equal(21, game.Players.FirstPlayer.Buildings.Tower);
        }

        [Theory, AutoFixture]
        public void ActivateWhenLessTowerTest(Game game,
            BagOfBaublesCard sut)
        {
            game.Players.FirstPlayer.Buildings.Tower = 19;

            sut.Activate(game);

            Assert.Equal(21, game.Players.FirstPlayer.Buildings.Tower);
        }
    }
}
