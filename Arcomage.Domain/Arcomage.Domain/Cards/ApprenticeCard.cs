using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class ApprenticeCard : GemsCard
    {
        public override int ResourcePrice { get; set; } = 5;

        public override void Activate(Game game)
        {
            game.GetCurrentPlayer().Buildings.Tower += 4;
            game.GetCurrentPlayer().Resources.Recruits -= 3;
            game.GetAdversaryPlayer().Buildings.Tower -= 2;
        }
    }
}
