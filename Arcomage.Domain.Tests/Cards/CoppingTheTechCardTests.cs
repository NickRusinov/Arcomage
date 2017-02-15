using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class CoppingTheTechCardTests
    {
        [Theory, AutoFixture]
        public void ActivateWhenNoLessQuarryTest(Game game,
            CoppingTheTechCard sut)
        {
            sut.Activate(game);

            Assert.Equal(2, game.Players.FirstPlayer.Resources.Quarry);
            Assert.Equal(2, game.Players.SecondPlayer.Resources.Quarry);
        }

        [Theory, AutoFixture]
        public void ActivateWhenLessQuarryTest(Game game,
            CoppingTheTechCard sut)
        {
            game.Players.FirstPlayer.Resources.Quarry = 1;

            sut.Activate(game);

            Assert.Equal(2, game.Players.FirstPlayer.Resources.Quarry);
            Assert.Equal(2, game.Players.SecondPlayer.Resources.Quarry);
        }
    }
}
