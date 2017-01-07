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
    public class LuckyCacheCard : BricksCard
    {
        public override int ResourcePrice { get; set; } = 0;

        public override void Activate(Game game)
        {
            game.CurrentPlayer.Resources.Bricks += 2;
            game.CurrentPlayer.Resources.Gems += 2;
            game.PlayAgain += 1;
        }
    }
}
