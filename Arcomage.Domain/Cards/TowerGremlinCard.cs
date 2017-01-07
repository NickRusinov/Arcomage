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
    public class TowerGremlinCard : RecruitsCard
    {
        public override int ResourcePrice { get; set; } = 8;

        public override void Activate(Game game)
        {
            game.AdversaryPlayer.Buildings.Damage(2);
            game.CurrentPlayer.Buildings.Wall += 4;
            game.CurrentPlayer.Buildings.Tower += 2;
        }
    }
}
