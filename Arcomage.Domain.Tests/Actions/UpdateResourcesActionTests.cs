using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Actions;
using Arcomage.Domain.Entities;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace Arcomage.Domain.Tests.Actions
{
    public class UpdateResourcesActionTests
    {
        [Theory, AutoFixture]
        public void UpdateResourcesTest(
            [Frozen] Game game,
            UpdateResourcesAction sut)
        {
            sut.Execute(game, game.FirstPlayer);

            Assert.Equal(7, game.FirstPlayer.Resources.Bricks);
            Assert.Equal(7, game.FirstPlayer.Resources.Gems);
            Assert.Equal(7, game.FirstPlayer.Resources.Recruits);
        }
    }
}
