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
    public class PhaseJewelCard : GemsCard
    {
        public override int ResourcePrice { get; set; } = 18;

        public override void Activate(Game game)
        {
            game.CurrentPlayer.Buildings.Tower += 13;
            game.CurrentPlayer.Resources.Recruits += 6;
            game.CurrentPlayer.Resources.Bricks += 6;
        }
    }
}
