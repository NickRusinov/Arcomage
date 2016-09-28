using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class WorkOvertimeCard : ClassicCard
    {
        public WorkOvertimeCard()
            : base("WorkOvertime", 2, ResourceMode.Bricks)
        {

        }

        public override void Activate(Game game)
        {
            game.GetCurrentPlayer().Buildings.Wall += 5;
            game.GetCurrentPlayer().Resources.Gems -= 6;

            base.Activate(game);
        }
    }
}
