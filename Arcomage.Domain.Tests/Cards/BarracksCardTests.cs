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
    public class BarracksCardTests
    {
        [Theory, AutoFixture]
        public void ActivateWhenNoLessDungeonsTest(Game game,
            BarracksCard sut)
        {
            sut.Activate(game);

            Assert.Equal(11, game.FirstPlayer.Buildings.Wall);
            Assert.Equal(11, game.FirstPlayer.Resources.Recruits);
            Assert.Equal(2, game.FirstPlayer.Resources.Dungeons);
        }

        [Theory, AutoFixture]
        public void ActivateWhenLessDungeonsTest(Game game,
            BarracksCard sut)
        {
            game.FirstPlayer.Resources.Dungeons = 1;

            sut.Activate(game);

            Assert.Equal(11, game.FirstPlayer.Buildings.Wall);
            Assert.Equal(11, game.FirstPlayer.Resources.Recruits);
            Assert.Equal(2, game.FirstPlayer.Resources.Dungeons);
        }
    }
}
