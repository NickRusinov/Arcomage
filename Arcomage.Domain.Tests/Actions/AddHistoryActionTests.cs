using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Actions;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace Arcomage.Domain.Tests.Actions
{
    public class AddHistoryActionTests
    {
        [Theory, AutoFixture]
        public void HistoryAddedTest(
            [Frozen] Game game,
            AddHistoryAction sut)
        {
            sut.Play(game, new PlayResult(1, true));

            Assert.Equal(game.Players.FirstPlayer.Hand.Cards[1], game.History.Cards.Last().Card);
        }
    }
}
