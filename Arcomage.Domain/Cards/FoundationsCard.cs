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
            if (game.CurrentPlayer.Buildings.Wall == 0)
                game.CurrentPlayer.Buildings.Wall += 6;
            else
                game.CurrentPlayer.Buildings.Wall += 3;
        }
    }
}
