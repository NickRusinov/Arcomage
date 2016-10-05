using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class CoppingTheTechCard : BricksCard
    {
        public override int ResourcePrice { get; set; } = 5;

        public override void Activate(Game game)
        {
            if (game.GetCurrentPlayer().Resources.Quarry < game.GetAdversaryPlayer().Resources.Quarry)
                game.GetCurrentPlayer().Resources.Quarry = game.GetAdversaryPlayer().Resources.Quarry;
        }
    }
}
