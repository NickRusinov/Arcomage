using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class SpearmanCard : RecruitsCard
    {
        public override int ResourcePrice { get; set; } = 2;

        public override void Activate(Game game)
        {
            if (game.CurrentPlayer.Buildings.Wall > game.AdversaryPlayer.Buildings.Wall)
                game.AdversaryPlayer.Buildings.Damage(3);
            else
                game.AdversaryPlayer.Buildings.Damage(2);
        }
    }
}
