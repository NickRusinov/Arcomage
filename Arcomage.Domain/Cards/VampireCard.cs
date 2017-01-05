using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class VampireCard : RecruitsCard
    {
        public override int ResourcePrice { get; set; } = 17;

        public override void Activate(Game game)
        {
            game.AdversaryPlayer.Buildings.Damage(10);
            game.AdversaryPlayer.Resources.Recruits -= 5;
            game.AdversaryPlayer.Resources.Dungeons -= 1;
        }
    }
}
