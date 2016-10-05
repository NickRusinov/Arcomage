using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class DragonsHeartCard : BricksCard
    {
        public override int ResourcePrice { get; set; } = 24;

        public override void Activate(Game game)
        {
            game.GetCurrentPlayer().Buildings.Wall += 20;
            game.GetCurrentPlayer().Buildings.Tower += 8;
        }
    }
}
