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
    public class BarracksCard : BricksCard
    {
        public override int ResourcePrice { get; set; } = 10;

        public override void Activate(Game game)
        {
            game.CurrentPlayer.Buildings.Wall += 6;
            game.CurrentPlayer.Resources.Recruits += 6;

            if (game.CurrentPlayer.Resources.Dungeons < game.AdversaryPlayer.Resources.Dungeons)
                game.CurrentPlayer.Resources.Dungeons += 1;
        }
    }
}
