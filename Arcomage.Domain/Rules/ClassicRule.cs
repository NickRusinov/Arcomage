using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Rules
{
    [Serializable]
    public class ClassicRule : Rule
    {
        private readonly ClassicRuleInfo ruleInfo;

        public ClassicRule(ClassicRuleInfo ruleInfo)
        {
            this.ruleInfo = ruleInfo;
        }

        public override Buildings CreateBuildings()
        {
            return new Buildings(ruleInfo.Wall, ruleInfo.Tower);
        }

        public override Resources CreateResources()
        {
            return new Resources(ruleInfo.Quarry, ruleInfo.Bricks, ruleInfo.Magic, ruleInfo.Gems, ruleInfo.Dungeons, ruleInfo.Recruits);
        }

        public override GameResult IsWin(Game game)
        {
            return IsWinPlayer(game.CurrentPlayer, game.AdversaryPlayer) ??
                IsWinPlayer(game.AdversaryPlayer, game.CurrentPlayer) ??
                GameResult.None;
        }

        private GameResult? IsWinPlayer(Player winPlayer, Player losePlayer)
        {
            if (winPlayer.Buildings.Tower >= ruleInfo.MaxTower)
                return new GameResult(winPlayer, isTowerBuild: true);

            if (losePlayer.Buildings.Tower <= 0)
                return new GameResult(winPlayer, isTowerDestroy: true);

            if (winPlayer.Resources.Bricks >= ruleInfo.MaxResources &&
                winPlayer.Resources.Gems >= ruleInfo.MaxResources &&
                winPlayer.Resources.Recruits >= ruleInfo.MaxResources)
                return new GameResult(winPlayer, isResourcesAccumulate: true);

            return null;
        }
    }
}
