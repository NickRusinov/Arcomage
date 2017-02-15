using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class QuarrysHelpCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            QuarrysHelpCard sut)
        {
            sut.Activate(game);

            Assert.Equal(27, game.Players.FirstPlayer.Buildings.Tower);
            Assert.Equal(0, game.Players.FirstPlayer.Resources.Bricks);
        }
    }
}
