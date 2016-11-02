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
    public class MinotaurCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            MinotaurCard sut)
        {
            sut.Activate(game);

            Assert.Equal(3, game.FirstPlayer.Resources.Dungeons);
        }
    }
}
