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
    public class ClearHistoryActionTests
    {
        [Theory, AutoFixture]
        public void HistoryClearedTest(
            [Frozen] Game game,
            ClearHistoryAction sut)
        {
            sut.Play(game);

            Assert.Empty(game.History.Cards);
        }
    }
}
