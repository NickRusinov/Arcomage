using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class CoppingTheTechCard : ClassicCard
    {
        public CoppingTheTechCard()
            : base("CoppingTheTech", 5, ResourceMode.Bricks)
        {

        }

        public override void Activate(Game game)
        {
            if (game.GetCurrentPlayer().Resources.Quarry < game.GetAdversaryPlayer().Resources.Quarry)
                game.GetCurrentPlayer().Resources.Quarry = game.GetAdversaryPlayer().Resources.Quarry;

            base.Activate(game);
        }
    }
}
