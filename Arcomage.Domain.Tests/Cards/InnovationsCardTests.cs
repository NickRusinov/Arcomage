using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class InnovationsCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            InnovationsCard sut)
        {
            sut.Activate(game);

            Assert.Equal(3, game.Players.FirstPlayer.Resources.Quarry);
            Assert.Equal(3, game.Players.SecondPlayer.Resources.Quarry);
            Assert.Equal(9, game.Players.FirstPlayer.Resources.Gems);
        }
    }
}
