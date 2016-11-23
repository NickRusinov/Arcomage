using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class InnovationsCard : BricksCard
    {
        public override int ResourcePrice { get; set; } = 2;

        public override void Activate(Game game)
        {
            game.FirstPlayer.Resources.Quarry += 1;
            game.SecondPlayer.Resources.Quarry += 1;
            game.GetCurrentPlayer().Resources.Gems += 4;
        }
    }
}
