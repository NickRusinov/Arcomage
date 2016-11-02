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
    public class GnomeCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            GnomeCard sut)
        {
            sut.Activate(game);

            Assert.Equal(2, game.SecondPlayer.Buildings.Wall);
            Assert.Equal(6, game.FirstPlayer.Resources.Gems);
        }
    }
}
