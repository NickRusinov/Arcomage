using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class ReinforcedWallCard : ClassicCard
    {
        public ReinforcedWallCard()
            : base("ReinforcedWall", 8, ResourceMode.Bricks)
        {

        }

        public override void Activate(Game game)
        {
            game.GetCurrentPlayer().Buildings.Wall += 8;

            base.Activate(game);
        }
    }
}
