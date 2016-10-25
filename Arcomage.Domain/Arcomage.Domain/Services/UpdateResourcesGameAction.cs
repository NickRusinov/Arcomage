using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Services
{
    public class UpdateResourcesGameAction : IGameAction
    {
        public void Execute(Game game, int cardIndex)
        {
            var player = game.GetCurrentPlayer();

            player.Resources.Bricks += player.Resources.Quarry;
            player.Resources.Gems += player.Resources.Magic;
            player.Resources.Recruits += player.Resources.Dungeons;
        }
    }
}
