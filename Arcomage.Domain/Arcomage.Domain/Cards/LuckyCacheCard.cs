using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class LuckyCacheCard : ClassicCard
    {
        public LuckyCacheCard()
            : base("LuckyCache", 0, ResourceMode.Bricks)
        {

        }

        public override void Activate(Game game)
        {
            game.GetCurrentPlayer().Resources.Bricks += 2;
            game.GetCurrentPlayer().Resources.Gems += 2;
        }
    }
}
