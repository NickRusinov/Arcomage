using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    [Serializable]
    public class BerserkerCard : RecruitsCard
    {
        public override int ResourcePrice { get; set; } = 4;

        public override void Activate(Game game)
        {
            game.AdversaryPlayer.Buildings.Damage(8);
            game.CurrentPlayer.Buildings.Tower -= 3;
        }
    }
}
