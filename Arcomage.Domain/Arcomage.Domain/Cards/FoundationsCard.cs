using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class FoundationsCard : ClassicCard
    {
        public FoundationsCard()
            : base("Foundations", 3, ResourceMode.Bricks)
        {

        }

        public override void Activate(Game game)
        {
            if (game.GetCurrentPlayer().Buildings.Wall == 0)
                game.GetCurrentPlayer().Buildings.Wall += 6;
            else
                game.GetCurrentPlayer().Buildings.Wall += 3;

            base.Activate(game);
        }
    }
}
