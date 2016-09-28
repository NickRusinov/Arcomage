using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    public class EarthquakeCard : ClassicCard
    {
        public EarthquakeCard()
            : base("Earthquake", 0, ResourceMode.Bricks)
        {

        }

        public override void Activate(Game game)
        {
            game.FirstPlayer.Resources.Quarry -= 1;
            game.SecondPlayer.Resources.Quarry -= 1;

            base.Activate(game);
        }
    }
}
