using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    [Serializable]
    public class EarthquakeCard : BricksCard
    {
        public override int ResourcePrice { get; set; } = 0;

        public override void Activate(Game game)
        {
            game.FirstPlayer.Resources.Quarry -= 1;
            game.SecondPlayer.Resources.Quarry -= 1;
        }
    }
}
