using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class BarracksCard : BricksCard
    {
        public override int ResourcePrice { get; set; } = 10;

        public override void Activate(Game game)
        {
            game.GetCurrentPlayer().Buildings.Wall += 6;
            game.GetCurrentPlayer().Resources.Recruits += 6;

            if (game.GetCurrentPlayer().Resources.Dungeons < game.GetAdversaryPlayer().Resources.Dungeons)
                game.GetCurrentPlayer().Resources.Dungeons += 1;
        }
    }
}
