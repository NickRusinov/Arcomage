using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class FoundationsCard : BricksCard
    {
        public override int ResourcePrice { get; set; } = 3;

        public override void Activate(Game game)
        {
            if (game.GetCurrentPlayer().Buildings.Wall == 0)
                game.GetCurrentPlayer().Buildings.Wall += 6;
            else
                game.GetCurrentPlayer().Buildings.Wall += 3;
        }
    }
}
