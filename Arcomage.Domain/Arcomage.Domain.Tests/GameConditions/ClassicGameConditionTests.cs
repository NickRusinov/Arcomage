using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.GameConditions;
using Moq;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace Arcomage.Domain.Tests.GameConditions
{
    public class ClassicGameConditionTests
    {
        [Theory, AutoFixture]
        public void CreateBuildingsTest(
            ClassicGameCondition sut)
        {
            var buildings = sut.CreateBuildings();

            Assert.Equal(sut.Buildings.Wall, buildings.Wall);
            Assert.Equal(sut.Buildings.Tower, buildings.Tower);
        }

        [Theory, AutoFixture]
        public void CreateResourcesTest(
            ClassicGameCondition sut)
        {
            var resources = sut.CreateResources();

            Assert.Equal(sut.Resources.Quarry, resources.Quarry);
            Assert.Equal(sut.Resources.Bricks, resources.Bricks);
            Assert.Equal(sut.Resources.Magic, resources.Magic);
            Assert.Equal(sut.Resources.Gems, resources.Gems);
            Assert.Equal(sut.Resources.Dungeons, resources.Dungeons);
            Assert.Equal(sut.Resources.Recruits, resources.Recruits);
        }

        [Theory, AutoFixture]
        public void IsWinWhenBuildTowerTest(Game game,
            [Frozen] Mock<IWinResultFactory> winResultFactoryMock,
            ClassicGameCondition sut)
        {
            sut.MaxTower = 15;

            var winResult = sut.IsWin(game);

            Assert.NotNull(winResult);
            winResultFactoryMock.Verify(wrf => wrf.CreateBuildTowerWinResult(PlayerMode.FirstPlayer), Times.Once);
        }

        [Theory, AutoFixture]
        public void IsWinWhenDestroyTowerTest(Game game,
            [Frozen] Mock<IWinResultFactory> winResultFactoryMock,
            ClassicGameCondition sut)
        {
            sut.MaxTower = 25;
            game.SecondPlayer.Buildings.Tower = 0;

            var winResult = sut.IsWin(game);

            Assert.NotNull(winResult);
            winResultFactoryMock.Verify(wrf => wrf.CreateDestroyTowerWinResult(PlayerMode.FirstPlayer), Times.Once);
        }

        [Theory, AutoFixture]
        public void IsWinWhenAccumulateResourcesTest(Game game,
            [Frozen] Mock<IWinResultFactory> winResultFactoryMock,
            ClassicGameCondition sut)
        {
            sut.MaxResources = 3;
            sut.MaxTower = 25;

            var winResult = sut.IsWin(game);

            Assert.NotNull(winResult);
            winResultFactoryMock.Verify(wrf => wrf.CreateAccumulateResourcesWinResult(PlayerMode.FirstPlayer), Times.Once);
        }

        [Theory, AutoFixture]
        public void IsWinWhenBuildTowerAdversaryTest(Game game,
            [Frozen] Mock<IWinResultFactory> winResultFactoryMock,
            ClassicGameCondition sut)
        {
            sut.MaxResources = 20;
            sut.MaxTower = 15;
            game.FirstPlayer.Buildings.Tower = 10;

            var winResult = sut.IsWin(game);

            Assert.NotNull(winResult);
            winResultFactoryMock.Verify(wrf => wrf.CreateBuildTowerWinResult(PlayerMode.SecondPlayer), Times.Once);
        }

        [Theory, AutoFixture]
        public void IsWinWhenDestroyTowerAdversaryTest(Game game,
            [Frozen] Mock<IWinResultFactory> winResultFactoryMock,
            ClassicGameCondition sut)
        {
            sut.MaxResources = 20;
            sut.MaxTower = 25;
            game.FirstPlayer.Buildings.Tower = 0;

            var winResult = sut.IsWin(game);

            Assert.NotNull(winResult);
            winResultFactoryMock.Verify(wrf => wrf.CreateDestroyTowerWinResult(PlayerMode.SecondPlayer), Times.Once);
        }

        [Theory, AutoFixture]
        public void IsWinWhenAccumulateResourcesAdversaryTest(Game game,
            [Frozen] Mock<IWinResultFactory> winResultFactoryMock,
            ClassicGameCondition sut)
        {
            sut.MaxResources = 3;
            sut.MaxTower = 25;
            game.FirstPlayer.Resources.Bricks = 0;

            var winResult = sut.IsWin(game);

            Assert.NotNull(winResult);
            winResultFactoryMock.Verify(wrf => wrf.CreateAccumulateResourcesWinResult(PlayerMode.SecondPlayer), Times.Once);
        }

        [Theory, AutoFixture]
        public void IsWinNoWinTest(Game game,
            ClassicGameCondition sut)
        {
            sut.MaxResources = 20;
            sut.MaxTower = 25;

            var winResult = sut.IsWin(game);

            Assert.Null(winResult);
        }
    }
}
