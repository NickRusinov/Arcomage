using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class CrystalMatrixCard : GemsCard
    {
        public override int ResourcePrice { get; set; } = 6;

        public override void Activate(Game game)
        {
            game.GetCurrentPlayer().Resources.Magic += 1;
            game.GetCurrentPlayer().Buildings.Tower += 3;
            game.GetAdversaryPlayer().Buildings.Tower += 1;
        }
    }
}
