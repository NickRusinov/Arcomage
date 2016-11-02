using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class LittleSnakesCard : RecruitsCard
    {
        public override int ResourcePrice { get; set; } = 6;

        public override void Activate(Game game)
        {
            game.GetAdversaryPlayer().Buildings.Tower -= 4;
        }
    }
}
