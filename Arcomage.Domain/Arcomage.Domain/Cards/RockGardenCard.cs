using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class RockGardenCard : BricksCard
    {
        public override int ResourcePrice { get; set; } = 1;

        public override void Activate(Game game)
        {
            game.GetCurrentPlayer().Buildings.Wall += 1;
            game.GetCurrentPlayer().Buildings.Tower += 1;
            game.GetCurrentPlayer().Resources.Recruits += 2;
        }
    }
}
