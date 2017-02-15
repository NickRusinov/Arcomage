using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class VampireCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            VampireCard sut)
        {
            sut.Activate(game);

            Assert.Equal(0, game.Players.SecondPlayer.Buildings.Wall);
            Assert.Equal(15, game.Players.SecondPlayer.Buildings.Tower);
            Assert.Equal(0, game.Players.SecondPlayer.Resources.Recruits);
            Assert.Equal(1, game.Players.SecondPlayer.Resources.Dungeons);
        }
    }
}
