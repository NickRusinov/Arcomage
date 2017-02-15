using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class PegasusLancerCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            PegasusLancerCard sut)
        {
            sut.Activate(game);

            Assert.Equal(8, game.Players.SecondPlayer.Buildings.Tower);
        }
    }
}
