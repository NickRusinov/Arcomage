using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class StoneGiantCard : RecruitsCard
    {
        public override int ResourcePrice { get; set; } = 15;

        public override void Activate(Game game)
        {
            game.AdversaryPlayer.Buildings.Damage(10);
            game.CurrentPlayer.Buildings.Wall += 4;
        }
    }
}
