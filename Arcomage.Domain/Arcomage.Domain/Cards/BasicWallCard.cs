using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class BasicWallCard : ClassicCard
    {
        public BasicWallCard()
            : base("BasicWall", 2, ResourceMode.Bricks)
        {

        }

        public override void Activate(Game game)
        {
            game.GetCurrentPlayer().Buildings.Wall += 3;

            base.Activate(game);
        }
    }
}
