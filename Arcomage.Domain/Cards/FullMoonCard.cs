using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class FullMoonCard : RecruitsCard
    {
        public override int ResourcePrice { get; set; } = 0;

        public override void Activate(Game game)
        {
            game.FirstPlayer.Resources.Dungeons += 1;
            game.SecondPlayer.Resources.Dungeons += 1;
            game.GetCurrentPlayer().Resources.Recruits += 3;
        }
    }
}
