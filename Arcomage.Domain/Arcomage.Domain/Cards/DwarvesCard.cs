using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class DwarvesCard : RecruitsCard
    {
        public override int ResourcePrice { get; set; } = 5;

        public override void Activate(Game game)
        {
            game.GetAdversaryPlayer().Buildings.Damage(4);
            game.GetCurrentPlayer().Buildings.Wall += 3;
        }
    }
}
