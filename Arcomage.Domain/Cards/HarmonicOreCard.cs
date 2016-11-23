using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class HarmonicOreCard : BricksCard
    {
        public override int ResourcePrice { get; set; } = 11;

        public override void Activate(Game game)
        {
            game.GetCurrentPlayer().Buildings.Wall += 6;
            game.GetCurrentPlayer().Buildings.Tower += 3;
        }
    }
}
