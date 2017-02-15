using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class ParityCardTests
    {
        [Theory, AutoFixture]
        public void ActivateWhenNoLessMagicTest(Game game,
            ParityCard sut)
        {
            sut.Activate(game);

            Assert.Equal(2, game.Players.FirstPlayer.Resources.Magic);
            Assert.Equal(2, game.Players.SecondPlayer.Resources.Magic);
        }

        [Theory, AutoFixture]
        public void ActivateWhenLessMagicTest(Game game,
            ParityCard sut)
        {
            game.Players.FirstPlayer.Resources.Magic = 1;

            sut.Activate(game);

            Assert.Equal(2, game.Players.FirstPlayer.Resources.Magic);
            Assert.Equal(2, game.Players.SecondPlayer.Resources.Magic);
        }
    }
}
