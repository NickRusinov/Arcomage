using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class ApprenticeCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            ApprenticeCard sut)
        {
            sut.Activate(game);

            Assert.Equal(24, game.Players.FirstPlayer.Buildings.Tower);
            Assert.Equal(18, game.Players.SecondPlayer.Buildings.Tower);
            Assert.Equal(2, game.Players.FirstPlayer.Resources.Recruits);
        }
    }
}
