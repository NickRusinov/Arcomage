using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class RockLauncherCard : BricksCard
    {
        public override int ResourcePrice { get; set; } = 18;

        public override void Activate(Game game)
        {
            game.CurrentPlayer.Buildings.Wall += 6;
            game.AdversaryPlayer.Buildings.Damage(10);
        }
    }
}
