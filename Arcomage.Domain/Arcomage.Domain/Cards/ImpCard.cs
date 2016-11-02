using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class ImpCard : RecruitsCard
    {
        public override int ResourcePrice { get; set; } = 5;

        public override void Activate(Game game)
        {
            game.GetAdversaryPlayer().Buildings.Damage(6);
            game.FirstPlayer.Resources.Bricks -= 5;
            game.FirstPlayer.Resources.Gems -= 5;
            game.FirstPlayer.Resources.Recruits -= 5;
            game.SecondPlayer.Resources.Bricks -= 5;
            game.SecondPlayer.Resources.Gems -= 5;
            game.SecondPlayer.Resources.Recruits -= 5;
        }
    }
}
