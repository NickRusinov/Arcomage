using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class NewEquipmentCard : ClassicCard
    {
        public NewEquipmentCard()
            : base("NewEquipment", 6, ResourceMode.Bricks)
        {

        }

        public override void Activate(Game game)
        {
            game.GetCurrentPlayer().Resources.Quarry += 2;

            base.Activate(game);
        }
    }
}
