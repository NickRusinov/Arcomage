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
            game.AdversaryPlayer.Buildings.Damage(20);
            game.AdversaryPlayer.Resources.Gems -= 10;
            game.AdversaryPlayer.Resources.Dungeons -= 1;
        }
    }
}
