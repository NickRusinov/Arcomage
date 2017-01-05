using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class EmpathyGemCard : GemsCard
    {
        public override int ResourcePrice { get; set; } = 14;

        public override void Activate(Game game)
        {
            game.CurrentPlayer.Buildings.Tower += 8;
            game.CurrentPlayer.Resources.Dungeons += 1;
        }
    }
}
