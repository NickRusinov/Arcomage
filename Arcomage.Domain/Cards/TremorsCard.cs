using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    [Serializable]
    public class TremorsCard : BricksCard
    {
        public override int ResourcePrice { get; set; } = 7;

        public override void Activate(Game game)
        {
            game.FirstPlayer.Buildings.Wall -= 5;
            game.SecondPlayer.Buildings.Wall -= 5;
            game.PlayAgain += 1;
        }
    }
}
