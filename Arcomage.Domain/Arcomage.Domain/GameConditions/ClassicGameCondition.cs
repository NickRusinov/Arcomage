using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;
using static Arcomage.Domain.Entities.PlayerMode;
using static Arcomage.Domain.Entities.WinMode;

namespace Arcomage.Domain.GameConditions
{
    public class ClassicGameCondition : GameCondition
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

        public override WinResult IsWin(Game game)
        {
            return 
                IsWinPlayer(game, FirstPlayer, game.PlayerMode) ??
                IsWinPlayer(game, SecondPlayer, game.PlayerMode.GetAdversary());
        }

        private WinResult IsWinPlayer(Game game, PlayerMode playerMode, PlayerMode winPlayerMode)
        {
            if (game.GetPlayer(playerMode).Buildings.Tower >= MaxTower)
                return new WinResult { WinPlayerMode = winPlayerMode, WinMode = BuildTower };

            if (game.GetPlayer(playerMode.GetAdversary()).Buildings.Tower <= 0)
                return new WinResult { WinPlayerMode = winPlayerMode, WinMode = DestroyTower };

            if (game.GetPlayer(playerMode).Resources.Bricks >= MaxResources &&
                game.GetPlayer(playerMode).Resources.Gems >= MaxResources &&
                game.GetPlayer(playerMode).Resources.Recruits >= MaxResources)
                return new WinResult { WinPlayerMode = winPlayerMode, WinMode = AccumulateResources };

            return null;
        }
    }
}
