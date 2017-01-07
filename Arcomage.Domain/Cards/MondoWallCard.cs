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
    public class MondoWallCard : BricksCard
    {
        public override int ResourcePrice { get; set; } = 13;

        public override void Activate(Game game)
        {
            game.CurrentPlayer.Buildings.Wall += 12;
        }
    }
}
