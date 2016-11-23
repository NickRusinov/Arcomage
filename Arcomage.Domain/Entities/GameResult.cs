using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Domain.Entities
{
    public struct GameResult
    {
        public static readonly GameResult None = new GameResult();

        public GameResult(Player player, bool isTowerBuild = false, bool isTowerDestroy = false, bool isResourcesAccumulate = false)
            : this()
        {
            Player = player;
            IsTowerBuild = isTowerBuild;
            IsTowerDestroy = isTowerDestroy;
            IsResourcesAccumulate = isResourcesAccumulate;
        }

        public Player Player { get; }

        public bool IsTowerBuild { get; }

        public bool IsTowerDestroy { get; }

        public bool IsResourcesAccumulate { get; }

        public static implicit operator bool(GameResult x) => !x.Equals(None);
    }
}
