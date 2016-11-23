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
    public class DragonCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            DragonCard sut)
        {
            sut.Activate(game);

            Assert.Equal(0, game.SecondPlayer.Buildings.Wall);
            Assert.Equal(5, game.SecondPlayer.Buildings.Tower);
            Assert.Equal(0, game.SecondPlayer.Resources.Gems);
            Assert.Equal(1, game.SecondPlayer.Resources.Dungeons);
        }
    }
}
