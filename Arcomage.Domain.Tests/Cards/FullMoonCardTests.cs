using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class FullMoonCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            FullMoonCard sut)
        {
            sut.Activate(game);

            Assert.Equal(3, game.Players.FirstPlayer.Resources.Dungeons);
            Assert.Equal(8, game.Players.FirstPlayer.Resources.Recruits);
            Assert.Equal(3, game.Players.SecondPlayer.Resources.Dungeons);
        }
    }
}
