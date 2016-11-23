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
    public class ForcedLaborCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            ForcedLaborCard sut)
        {
            sut.Activate(game);

            Assert.Equal(14, game.FirstPlayer.Buildings.Wall);
            Assert.Equal(0, game.FirstPlayer.Resources.Recruits);
        }
    }
}
