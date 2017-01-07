using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    [Serializable]
    public class FloodWaterCard : BricksCard
    {
        public override int ResourcePrice { get; set; } = 6;

        public override void Activate(Game game)
        {
            if (game.CurrentPlayer.Buildings.Wall < game.AdversaryPlayer.Buildings.Wall)
            {
                game.CurrentPlayer.Buildings.Tower -= 2;
                game.CurrentPlayer.Resources.Dungeons -= 1;
            }
            if (game.CurrentPlayer.Buildings.Wall > game.AdversaryPlayer.Buildings.Wall)
            {
                game.AdversaryPlayer.Buildings.Tower -= 2;
                game.AdversaryPlayer.Resources.Dungeons -= 1;
            }
        }
    }
}
