using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Actions
{
    public class UpdateResourcesAction : IPlayAction
    {
        public void Execute(Game game, Player player)
        {
            player.Resources.Bricks += player.Resources.Quarry;
            player.Resources.Gems += player.Resources.Magic;
            player.Resources.Recruits += player.Resources.Dungeons;
        }
    }
}
