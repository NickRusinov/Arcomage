using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class ElvenArchersCard : RecruitsCard
    {
        public override int ResourcePrice { get; set; } = 10;

        public override void Activate(Game game)
        {
            if (game.GetCurrentPlayer().Buildings.Wall > game.GetAdversaryPlayer().Buildings.Wall)
                game.GetAdversaryPlayer().Buildings.Tower -= 6;
            else
                game.GetAdversaryPlayer().Buildings.Damage(6);
        }
    }
}
