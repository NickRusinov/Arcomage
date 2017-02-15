using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class UnicornCardTests
    {
        [Theory, AutoFixture]
        public void ActivateWhenMoreMagicTest(Game game,
            UnicornCard sut)
        {
            game.Players.FirstPlayer.Resources.Magic = 3;

            sut.Activate(game);

            Assert.Equal(0, game.Players.SecondPlayer.Buildings.Wall);
            Assert.Equal(13, game.Players.SecondPlayer.Buildings.Tower);
        }

        [Theory, AutoFixture]
        public void ActivateWhenNoMoreMagicTest(Game game,
            UnicornCard sut)
        {
            sut.Activate(game);

            Assert.Equal(0, game.Players.SecondPlayer.Buildings.Wall);
            Assert.Equal(17, game.Players.SecondPlayer.Buildings.Tower);
        }
    }
}
