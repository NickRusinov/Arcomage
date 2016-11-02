using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class UnicornCard : RecruitsCard
    {
        public override int ResourcePrice { get; set; } = 9;

        public override void Activate(Game game)
        {
            if (game.GetCurrentPlayer().Resources.Magic > game.GetAdversaryPlayer().Resources.Magic)
                game.GetAdversaryPlayer().Buildings.Damage(12);
            else
                game.GetAdversaryPlayer().Buildings.Damage(8);
        }
    }
}
