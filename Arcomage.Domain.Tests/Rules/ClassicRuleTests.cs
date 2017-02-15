using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Players;
using Arcomage.Domain.Rules;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace Arcomage.Domain.Tests.Rules
{
    public class ClassicRuleTests
    {
        [Theory, AutoFixture]
        public void CreateBuildingsTest(
            [Frozen] ClassicRuleInfo ruleInfo,
            ClassicRule sut)
        {
            var buildings = sut.CreateBuildings();

            Assert.Equal(ruleInfo.Wall, buildings.Wall);
            Assert.Equal(ruleInfo.Tower, buildings.Tower);
        }

        [Theory, AutoFixture]
        public void CreateResourcesTest(
            [Frozen] ClassicRuleInfo ruleInfo,
            ClassicRule sut)
        {
            var resources = sut.CreateResources();

            Assert.Equal(ruleInfo.Quarry, resources.Quarry);
            Assert.Equal(ruleInfo.Bricks, resources.Bricks);
            Assert.Equal(ruleInfo.Magic, resources.Magic);
            Assert.Equal(ruleInfo.Gems, resources.Gems);
            Assert.Equal(ruleInfo.Dungeons, resources.Dungeons);
            Assert.Equal(ruleInfo.Recruits, resources.Recruits);
        }

        [Theory, AutoFixture]
        public void IsWinWhenBuildTowerTest(
            [Frozen] Game game,
            ClassicRule sut)
        {
            game.Players.FirstPlayer.Buildings.Tower = 55;

            var gameResult = sut.IsWin(game);

            Assert.True(gameResult.IsTowerBuild);
            Assert.Equal(PlayerKind.First, gameResult.Player);
        }

        [Theory, AutoFixture]
        public void IsWinWhenDestroyTowerTest(
            [Frozen] Game game,
            ClassicRule sut)
        {
            game.Players.SecondPlayer.Buildings.Tower = 0;

            var gameResult = sut.IsWin(game);

            Assert.True(gameResult.IsTowerDestroy);
            Assert.Equal(PlayerKind.First, gameResult.Player);
        }

        [Theory, AutoFixture]
        public void IsWinWhenAccumulateResourcesTest(
            [Frozen] Game game,
            ClassicRule sut)
        {
            game.Players.FirstPlayer.Resources.Bricks = 160;
            game.Players.FirstPlayer.Resources.Gems = 160;
            game.Players.FirstPlayer.Resources.Recruits = 160;

            var gameResult = sut.IsWin(game);

            Assert.True(gameResult.IsResourcesAccumulate);
            Assert.Equal(PlayerKind.First, gameResult.Player);
        }

        [Theory, AutoFixture]
        public void IsWinWhenBuildTowerAdversaryTest(
            [Frozen] Game game,
            ClassicRule sut)
        {
            game.Players.SecondPlayer.Buildings.Tower = 55;

            var gameResult = sut.IsWin(game);

            Assert.True(gameResult.IsTowerBuild);
            Assert.Equal(PlayerKind.Second, gameResult.Player);
        }

        [Theory, AutoFixture]
        public void IsWinWhenDestroyTowerAdversaryTest(
            [Frozen] Game game,
            ClassicRule sut)
        {
            game.Players.FirstPlayer.Buildings.Tower = 0;

            var gameResult = sut.IsWin(game);

            Assert.True(gameResult.IsTowerDestroy);
            Assert.Equal(PlayerKind.Second, gameResult.Player);
        }

        [Theory, AutoFixture]
        public void IsWinWhenAccumulateResourcesAdversaryTest(
            [Frozen] Game game,
            ClassicRule sut)
        {
            game.Players.SecondPlayer.Resources.Bricks = 160;
            game.Players.SecondPlayer.Resources.Gems = 160;
            game.Players.SecondPlayer.Resources.Recruits = 160;

            var gameResult = sut.IsWin(game);

            Assert.True(gameResult.IsResourcesAccumulate);
            Assert.Equal(PlayerKind.Second, gameResult.Player);
        }

        [Theory, AutoFixture]
        public void IsWinNoWinTest(
            [Frozen] Game game,
            ClassicRule sut)
        {
            var gameResult = sut.IsWin(game);

            Assert.Equal(GameResult.None, gameResult);
        }
    }
}
