using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class FocusedDesignsCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            FocusedDesignsCard sut)
        {
            sut.Activate(game);

            Assert.Equal(13, game.Players.FirstPlayer.Buildings.Wall);
            Assert.Equal(25, game.Players.FirstPlayer.Buildings.Tower);
        }
    }
}
