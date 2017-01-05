using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Domain.Rules
{
    public class ClassicRuleInfo : RuleInfo
    {
        public ClassicRuleInfo(string identifier, int quarry, int bricks, int magic, int gems, int dungeons, int recruits, int wall, int tower, int maxTower, int maxResources)
            : base(identifier)
        {
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
        
        public int Quarry { get; }

        public int Bricks { get; }

        public int Magic { get; }

        public int Gems { get; }

        public int Dungeons { get; }

        public int Recruits { get; }

        public int Wall { get; }

        public int Tower { get; }

        public int MaxTower { get; }

        public int MaxResources { get; }
    }
}
