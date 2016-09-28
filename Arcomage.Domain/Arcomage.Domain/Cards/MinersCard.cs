using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class MinersCard : ClassicCard
    {
        public MinersCard()
            : base("Miners", 3, ResourceMode.Bricks)
        {

        }

        public override void Activate(Game game)
        {
            game.GetCurrentPlayer().Resources.Quarry += 1;

            base.Activate(game);
        }
    }
}
