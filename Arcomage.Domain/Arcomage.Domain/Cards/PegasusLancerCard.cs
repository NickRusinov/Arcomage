using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class PegasusLancerCard : RecruitsCard
    {
        public override int ResourcePrice { get; set; } = 18;

        public override void Activate(Game game)
        {
            game.GetAdversaryPlayer().Buildings.Tower -= 12;
        }
    }
}
