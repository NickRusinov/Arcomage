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
    public class ShiftCard : BricksCard
    {
        public override int ResourcePrice { get; set; } = 17;

        public override void Activate(Game game)
        {
            var currentWall = game.CurrentPlayer.Buildings.Wall;
            var adversaryWall = game.AdversaryPlayer.Buildings.Wall;

            game.CurrentPlayer.Buildings.Wall = adversaryWall;
            game.AdversaryPlayer.Buildings.Wall = currentWall;
        }
    }
}
