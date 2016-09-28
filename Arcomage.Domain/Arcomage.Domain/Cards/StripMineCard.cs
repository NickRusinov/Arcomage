using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class StripMineCard : ClassicCard
    {
        public StripMineCard()
            : base("StripMine", 0, ResourceMode.Bricks)
        {

        }

        public override void Activate(Game game)
        {
            game.GetCurrentPlayer().Resources.Quarry -= 1;
            game.GetCurrentPlayer().Buildings.Wall += 10;
            game.GetCurrentPlayer().Resources.Gems += 5;

            base.Activate(game);
        }
    }
}
