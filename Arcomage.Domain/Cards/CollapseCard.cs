using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class CollapseCard : BricksCard
    {
        public override int ResourcePrice { get; set; } = 4;

        public override void Activate(Game game)
        {
            game.AdversaryPlayer.Resources.Quarry -= 1;
        }
    }
}
