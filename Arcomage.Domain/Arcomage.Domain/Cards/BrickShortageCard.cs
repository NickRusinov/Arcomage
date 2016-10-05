using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    public class BrickShortageCard : BricksCard
    {
        public override int ResourcePrice { get; set; } = 0;

        public override void Activate(Game game)
        {
            game.FirstPlayer.Resources.Bricks -= 8;
            game.SecondPlayer.Resources.Bricks -= 8;
        }
    }
}
