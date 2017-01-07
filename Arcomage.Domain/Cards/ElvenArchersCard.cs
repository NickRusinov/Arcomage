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
    public class ElvenArchersCard : RecruitsCard
    {
        public override int ResourcePrice { get; set; } = 10;

        public override void Activate(Game game)
        {
            if (game.CurrentPlayer.Buildings.Wall > game.AdversaryPlayer.Buildings.Wall)
                game.AdversaryPlayer.Buildings.Tower -= 6;
            else
                game.AdversaryPlayer.Buildings.Damage(6);
        }
    }
}
