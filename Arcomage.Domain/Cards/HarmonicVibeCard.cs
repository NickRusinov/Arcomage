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
    public class HarmonicVibeCard : GemsCard
    {
        public override int ResourcePrice { get; set; } = 7;

        public override void Activate(Game game)
        {
            game.CurrentPlayer.Resources.Magic += 1;
            game.CurrentPlayer.Buildings.Tower += 3;
            game.CurrentPlayer.Buildings.Wall += 3;
        }
    }
}
