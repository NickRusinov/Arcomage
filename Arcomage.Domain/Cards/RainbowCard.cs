using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    [Serializable]
    public class RainbowCard : GemsCard
    {
        public override int ResourcePrice { get; set; } = 0;

        public override void Activate(Game game)
        {
            game.FirstPlayer.Buildings.Tower += 1;
            game.SecondPlayer.Buildings.Tower += 1;
            game.CurrentPlayer.Resources.Gems += 3;
        }
    }
}
