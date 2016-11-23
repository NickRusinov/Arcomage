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
    public class ClearHistoryActionTests
    {
        [Theory, AutoFixture]
        public void HistoryClearedTest(
            [Frozen] Game game,
            ClearHistoryAction sut)
        {
            sut.Execute(game, game.FirstPlayer);

            Assert.Empty(game.History.Cards);
        }
    }
}
