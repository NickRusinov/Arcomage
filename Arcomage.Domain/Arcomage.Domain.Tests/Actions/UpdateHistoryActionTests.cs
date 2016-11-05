using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Actions;
using Arcomage.Domain.Entities;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace Arcomage.Domain.Tests.Actions
{
    public class UpdateHistoryActionTests
    {
        [Theory, AutoFixture]
        public void HistoryAddedTest(
            [Frozen] Game game,
            UpdateHistoryAction sut)
        {
            sut.PlayExecute(game, game.FirstPlayer, 1);

            Assert.Equal(game.FirstPlayer.Hand.Cards[1], game.History.Cards.Last());
        }
    }
}
