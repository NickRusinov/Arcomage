using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class PrismCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            PrismCard sut)
        {
            sut.Activate(game);

            Assert.Equal(2, game.PlayAgain);
        }
    }
}
