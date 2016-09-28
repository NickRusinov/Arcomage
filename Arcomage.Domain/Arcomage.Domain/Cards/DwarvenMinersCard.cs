using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class DwarvenMinersCard : ClassicCard
    {
        public DwarvenMinersCard()
            : base("DwarvenMiners", 7, ResourceMode.Bricks)
        {

        }

        public override void Activate(Game game)
        {
            game.GetCurrentPlayer().Buildings.Wall += 4;
            game.GetCurrentPlayer().Resources.Quarry += 1;

            base.Activate(game);
        }
    }
}
