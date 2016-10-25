using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Services;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace Arcomage.Domain.Tests.Services
{
    public class UpdateResourcesGameActionTests
    {
        [Theory, AutoFixture]
        public void UpdateResourcesTest(
            [Frozen] Game game,
            UpdateResourcesGameAction sut)
        {
            sut.Execute(game, 1);

            Assert.Equal(7, game.FirstPlayer.Resources.Bricks);
            Assert.Equal(7, game.FirstPlayer.Resources.Gems);
            Assert.Equal(7, game.FirstPlayer.Resources.Recruits);
        }
    }
}
