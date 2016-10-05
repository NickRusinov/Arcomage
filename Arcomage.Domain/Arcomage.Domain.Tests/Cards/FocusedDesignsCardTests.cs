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
    public class FocusedDesignsCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            FocusedDesignsCard sut)
        {
            sut.Activate(game);

            Assert.Equal(13, game.FirstPlayer.Buildings.Wall);
            Assert.Equal(25, game.FirstPlayer.Buildings.Tower);
        }
    }
}
