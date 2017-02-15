using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
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

            Assert.Equal(13, game.Players.FirstPlayer.Buildings.Tower);
            Assert.Equal(13, game.Players.SecondPlayer.Buildings.Tower);
            Assert.Equal(1, game.Players.FirstPlayer.Resources.Magic);
            Assert.Equal(1, game.Players.SecondPlayer.Resources.Magic);
        }
    }
}
