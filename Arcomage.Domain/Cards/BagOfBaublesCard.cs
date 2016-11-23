using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class BagOfBaublesCard : GemsCard
    {
        public override int ResourcePrice { get; set; } = 0;

        public override void Activate(Game game)
        {
            if (game.GetCurrentPlayer().Buildings.Tower < game.GetAdversaryPlayer().Buildings.Tower)
                game.GetCurrentPlayer().Buildings.Tower += 2;
            else
                game.GetCurrentPlayer().Buildings.Tower += 1;
        }
    }
}
