using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class DragonCard : RecruitsCard
    {
        public override int ResourcePrice { get; set; } = 25;

        public override void Activate(Game game)
        {
            game.GetAdversaryPlayer().Buildings.Damage(20);
            game.GetAdversaryPlayer().Resources.Gems -= 10;
            game.GetAdversaryPlayer().Resources.Dungeons -= 1;
        }
    }
}
