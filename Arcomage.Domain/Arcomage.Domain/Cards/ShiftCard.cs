using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class ShiftCard : BricksCard
    {
        public override int ResourcePrice { get; set; } = 17;

        public override void Activate(Game game)
        {
            var currentWall = game.GetCurrentPlayer().Buildings.Wall;
            var adversaryWall = game.GetAdversaryPlayer().Buildings.Wall;

            game.GetCurrentPlayer().Buildings.Wall = adversaryWall;
            game.GetAdversaryPlayer().Buildings.Wall = currentWall;
        }
    }
}
