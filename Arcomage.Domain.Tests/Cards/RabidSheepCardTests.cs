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
    public class RabidSheepCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            RabidSheepCard sut)
        {
            sut.Activate(game);

            Assert.Equal(0, game.SecondPlayer.Buildings.Wall);
            Assert.Equal(19, game.SecondPlayer.Buildings.Tower);
            Assert.Equal(2, game.SecondPlayer.Resources.Recruits);
        }
    }
}
