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
    public class ApprenticeCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            ApprenticeCard sut)
        {
            sut.Activate(game);

            Assert.Equal(24, game.FirstPlayer.Buildings.Tower);
            Assert.Equal(18, game.SecondPlayer.Buildings.Tower);
            Assert.Equal(2, game.FirstPlayer.Resources.Recruits);
        }
    }
}
