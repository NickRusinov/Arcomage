using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Rules
{
    public class ClassicRule : Rule
    {
        public Buildings Buildings { get; set; }

        public Resources Resources { get; set; }

        public int MaxTower { get; set; }

        public int MaxResources { get; set; }

        public override Buildings CreateBuildings()
        {
            return new Buildings
            {
                Wall = Buildings.Wall,
                Tower = Buildings.Tower
            };
        }

        public override Resources CreateResources()
        {
            return new Resources
            {
                Quarry = Resources.Quarry,
                Bricks = Resources.Bricks,
                Magic = Resources.Magic,
                Gems = Resources.Gems,
                Dungeons = Resources.Dungeons,
                Recruits = Resources.Recruits
            };
        }

        public override GameResult IsWin(Game game)
        {
            return 
                IsWinPlayer(game, PlayerMode.FirstPlayer, game.GetCurrentPlayer()) ??
                IsWinPlayer(game, PlayerMode.SecondPlayer, game.GetAdversaryPlayer()) ??
                GameResult.None;
        }

        private GameResult? IsWinPlayer(Game game, PlayerMode playerMode, Player winPlayer)
        {
            if (game.GetPlayer(playerMode).Buildings.Tower >= MaxTower)
                return new GameResult(winPlayer, isTowerBuild: true);

            if (game.GetPlayer(playerMode.GetAdversary()).Buildings.Tower <= 0)
                return new GameResult(winPlayer, isTowerDestroy: true);

            if (game.GetPlayer(playerMode).Resources.Bricks >= MaxResources &&
                game.GetPlayer(playerMode).Resources.Gems >= MaxResources &&
                game.GetPlayer(playerMode).Resources.Recruits >= MaxResources)
                return new GameResult(winPlayer, isResourcesAccumulate: true);

            return null;
        }
    }
}
