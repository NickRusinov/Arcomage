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
    public class DiscordCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            DiscordCard sut)
        {
            sut.Activate(game);

            Assert.Equal(13, game.FirstPlayer.Buildings.Tower);
            Assert.Equal(13, game.SecondPlayer.Buildings.Tower);
            Assert.Equal(1, game.FirstPlayer.Resources.Magic);
            Assert.Equal(1, game.SecondPlayer.Resources.Magic);
        }
    }
}
