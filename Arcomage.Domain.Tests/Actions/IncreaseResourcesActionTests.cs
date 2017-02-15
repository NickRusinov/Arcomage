using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Actions;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace Arcomage.Domain.Tests.Actions
{
    public class IncreaseResourcesActionTests
    {
        [Theory, AutoFixture]
        public void UpdateResourcesTest(
            [Frozen] Game game,
            IncreaseResourcesAction sut)
        {
            sut.Play(game);

            Assert.Equal(7, game.Players.FirstPlayer.Resources.Bricks);
            Assert.Equal(7, game.Players.FirstPlayer.Resources.Gems);
            Assert.Equal(7, game.Players.FirstPlayer.Resources.Recruits);
        }
    }
}
