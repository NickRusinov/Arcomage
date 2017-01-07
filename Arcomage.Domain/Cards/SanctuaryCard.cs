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
    public class SanctuaryCard : GemsCard
    {
        public override int ResourcePrice { get; set; } = 15;

        public override void Activate(Game game)
        {
            game.CurrentPlayer.Buildings.Tower += 10;
            game.CurrentPlayer.Buildings.Wall += 5;
            game.CurrentPlayer.Resources.Recruits += 5;
        }
    }
}
