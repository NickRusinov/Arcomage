using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class BarracksCardTests
    {
        [Theory, AutoFixture]
        public void ActivateWhenNoLessDungeonsTest(Game game,
            BarracksCard sut)
        {
            sut.Activate(game);

            Assert.Equal(11, game.Players.FirstPlayer.Buildings.Wall);
            Assert.Equal(11, game.Players.FirstPlayer.Resources.Recruits);
            Assert.Equal(2, game.Players.FirstPlayer.Resources.Dungeons);
        }

        [Theory, AutoFixture]
        public void ActivateWhenLessDungeonsTest(Game game,
            BarracksCard sut)
        {
            game.Players.FirstPlayer.Resources.Dungeons = 1;

            sut.Activate(game);

            Assert.Equal(11, game.Players.FirstPlayer.Buildings.Wall);
            Assert.Equal(11, game.Players.FirstPlayer.Resources.Recruits);
            Assert.Equal(2, game.Players.FirstPlayer.Resources.Dungeons);
        }
    }
}
