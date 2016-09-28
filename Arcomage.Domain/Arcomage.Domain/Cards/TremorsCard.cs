using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    public class TremorsCard : ClassicCard
    {
        public TremorsCard()
            : base("Tremors", 7, ResourceMode.Bricks)
        {

        }

        public override void Activate(Game game)
        {
            game.FirstPlayer.Buildings.Wall -= 5;
            game.SecondPlayer.Buildings.Wall -= 5;
        }
    }
}
