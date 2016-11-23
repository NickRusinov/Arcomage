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
    public class CoppingTheTechCardTests
    {
        [Theory, AutoFixture]
        public void ActivateWhenNoLessQuarryTest(Game game,
            CoppingTheTechCard sut)
        {
            sut.Activate(game);

            Assert.Equal(2, game.FirstPlayer.Resources.Quarry);
            Assert.Equal(2, game.SecondPlayer.Resources.Quarry);
        }

        [Theory, AutoFixture]
        public void ActivateWhenLessQuarryTest(Game game,
            CoppingTheTechCard sut)
        {
            game.FirstPlayer.Resources.Quarry = 1;

            sut.Activate(game);

            Assert.Equal(2, game.FirstPlayer.Resources.Quarry);
            Assert.Equal(2, game.SecondPlayer.Resources.Quarry);
        }
    }
}
