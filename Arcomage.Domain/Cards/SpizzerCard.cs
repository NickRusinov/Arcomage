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
    public class SpizzerCard : RecruitsCard
    {
        public override int ResourcePrice { get; set; } = 8;

        public override void Activate(Game game)
        {
            if (game.AdversaryPlayer.Buildings.Wall == 0)
                game.AdversaryPlayer.Buildings.Damage(10);
            else
                game.AdversaryPlayer.Buildings.Damage(6);
        }
    }
}
