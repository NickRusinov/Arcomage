using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class FloodWaterCard : BricksCard
    {
        public override int ResourcePrice { get; set; } = 6;

        public override void Activate(Game game)
        {
            if (game.GetCurrentPlayer().Buildings.Wall < game.GetAdversaryPlayer().Buildings.Wall)
            {
                game.GetCurrentPlayer().Buildings.Tower -= 2;
                game.GetCurrentPlayer().Resources.Dungeons -= 1;
            }
            if (game.GetCurrentPlayer().Buildings.Wall > game.GetAdversaryPlayer().Buildings.Wall)
            {
                game.GetAdversaryPlayer().Buildings.Tower -= 2;
                game.GetAdversaryPlayer().Resources.Dungeons -= 1;
            }
        }
    }
}
