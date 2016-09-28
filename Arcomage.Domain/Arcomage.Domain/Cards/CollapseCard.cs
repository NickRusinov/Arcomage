using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class CollapseCard : ClassicCard
    {
        public CollapseCard()
            : base("Collapse", 4, ResourceMode.Bricks)
        {

        }

        public override void Activate(Game game)
        {
            game.GetAdversaryPlayer().Resources.Quarry -= 1;

            base.Activate(game);
        }
    }
}
