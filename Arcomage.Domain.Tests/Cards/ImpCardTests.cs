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
    public class ImpCardTests
    {
        [Theory, AutoFixture]
        public void ActivateCard(Game game,
            ImpCard sut)
        {
            sut.Activate(game);

            Assert.Equal(0, game.SecondPlayer.Buildings.Wall);
            Assert.Equal(19, game.SecondPlayer.Buildings.Tower);
            Assert.Equal(0, game.FirstPlayer.Resources.Bricks);
            Assert.Equal(0, game.FirstPlayer.Resources.Gems);
            Assert.Equal(0, game.FirstPlayer.Resources.Recruits);
            Assert.Equal(0, game.SecondPlayer.Resources.Bricks);
            Assert.Equal(0, game.SecondPlayer.Resources.Gems);
            Assert.Equal(0, game.SecondPlayer.Resources.Recruits);
        }
    }
}
