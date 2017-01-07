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
    public class LavaJewelCard : GemsCard
    {
        public override int ResourcePrice { get; set; } = 17;

        public override void Activate(Game game)
        {
            game.CurrentPlayer.Buildings.Tower += 12;
            game.AdversaryPlayer.Buildings.Damage(6);
        }
    }
}
