using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class SturdyWallCard : ClassicCard
    {
        public SturdyWallCard()
            : base("SturdyWall", 3, ResourceMode.Bricks)
        {

        }

        public override void Activate(Game game)
        {
            game.GetCurrentPlayer().Buildings.Wall += 4;

            base.Activate(game);
        }
    }
}
