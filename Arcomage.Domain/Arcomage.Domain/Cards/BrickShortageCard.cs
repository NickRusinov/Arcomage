using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    public class BrickShortageCard : ClassicCard
    {
        public BrickShortageCard()
            : base("BrickShortage", 0, ResourceMode.Bricks)
        {

        }

        public override void Activate(Game game)
        {
            game.FirstPlayer.Resources.Bricks -= 8;
            game.SecondPlayer.Resources.Bricks -= 8;

            base.Activate(game);
        }
    }
}
