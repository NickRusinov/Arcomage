using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Services;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace Arcomage.Domain.Tests.Services
{
    public class DiscardCardCriteriaTests
    {
        [Theory, AutoFixture]
        public void CanDiscardCardTest(
            [Frozen] Game game,
            DiscardCardCriteria sut)
        {
            var canDiscardCard = sut.CanDiscardCard(game, game.Players.FirstPlayer, 1);

            Assert.True(canDiscardCard);
        }
    }
}
