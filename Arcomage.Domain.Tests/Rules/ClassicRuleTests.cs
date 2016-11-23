using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Rules;
using Xunit;

namespace Arcomage.Domain.Tests.Rules
{
    public class ClassicRuleTests
    {
        [Theory, AutoFixture]
        public void CreateBuildingsTest(
            ClassicRule sut)
        {
            var buildings = sut.CreateBuildings();

            Assert.Equal(sut.Buildings.Wall, buildings.Wall);
            Assert.Equal(sut.Buildings.Tower, buildings.Tower);
        }

        [Theory, AutoFixture]
        public void CreateResourcesTest(
            ClassicRule sut)
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
            ClassicRule sut)
        {
            sut.MaxTower = 15;

            var gameResult = sut.IsWin(game);

            Assert.True(gameResult.IsTowerBuild);
            Assert.Equal(game.FirstPlayer, gameResult.Player);
        }

        [Theory, AutoFixture]
        public void IsWinWhenDestroyTowerTest(Game game,
            ClassicRule sut)
        {
            sut.MaxTower = 25;
            game.SecondPlayer.Buildings.Tower = 0;

            var gameResult = sut.IsWin(game);

            Assert.True(gameResult.IsTowerDestroy);
            Assert.Equal(game.FirstPlayer, gameResult.Player);
        }

        [Theory, AutoFixture]
        public void IsWinWhenAccumulateResourcesTest(Game game,
            ClassicRule sut)
        {
            sut.MaxResources = 3;
            sut.MaxTower = 25;

            var gameResult = sut.IsWin(game);

            Assert.True(gameResult.IsResourcesAccumulate);
            Assert.Equal(game.FirstPlayer, gameResult.Player);
        }

        [Theory, AutoFixture]
        public void IsWinWhenBuildTowerAdversaryTest(Game game,
            ClassicRule sut)
        {
            sut.MaxResources = 20;
            sut.MaxTower = 15;
            game.FirstPlayer.Buildings.Tower = 10;

            var gameResult = sut.IsWin(game);

            Assert.True(gameResult.IsTowerBuild);
            Assert.Equal(game.SecondPlayer, gameResult.Player);
        }

        [Theory, AutoFixture]
        public void IsWinWhenDestroyTowerAdversaryTest(Game game,
            ClassicRule sut)
        {
            sut.MaxResources = 20;
            sut.MaxTower = 25;
            game.FirstPlayer.Buildings.Tower = 0;

            var gameResult = sut.IsWin(game);

            Assert.True(gameResult.IsTowerDestroy);
            Assert.Equal(game.SecondPlayer, gameResult.Player);
        }

        [Theory, AutoFixture]
        public void IsWinWhenAccumulateResourcesAdversaryTest(Game game,
            ClassicRule sut)
        {
            sut.MaxResources = 3;
            sut.MaxTower = 25;
            game.FirstPlayer.Resources.Bricks = 0;

            var gameResult = sut.IsWin(game);

            Assert.True(gameResult.IsResourcesAccumulate);
            Assert.Equal(game.SecondPlayer, gameResult.Player);
        }

        [Theory, AutoFixture]
        public void IsWinNoWinTest(Game game,
            ClassicRule sut)
        {
            sut.MaxResources = 20;
            sut.MaxTower = 25;

            var gameResult = sut.IsWin(game);

            Assert.Equal(GameResult.None, gameResult);
        }
    }
}
