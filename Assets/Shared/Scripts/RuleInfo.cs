using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Unity.Shared.Scripts
{
    public class RuleInfo
    {
        public string Identifier;

        public int Quarry;

        public int Bricks;

        public int Magic;

        public int Gems;

        public int Dungeons;

        public int Recruits;

        public int Wall;

        public int Tower;

        public int MaxTower;

        public int MaxResources;

        public RuleInfo(string identifier, int quarry, int bricks, int magic, int gems, int dungeons, int recruits, int wall, int tower, int maxTower, int maxResources)
        {
            Identifier = identifier;
            Quarry = quarry;
            Bricks = bricks;
            Magic = magic;
            Gems = gems;
            Dungeons = dungeons;
            Recruits = recruits;
            Wall = wall;
            Tower = tower;
            MaxTower = maxTower;
            MaxResources = maxResources;
        }

        public string[] GetArguments()
        {
            return new[]
            {
                Quarry.ToString(),
                Bricks.ToString(),
                Magic.ToString(),
                Gems.ToString(),
                Dungeons.ToString(),
                Recruits.ToString(),
                Wall.ToString(),
                Tower.ToString(),
                MaxTower.ToString(),
                MaxResources.ToString(),
            };
        }
    }
}
