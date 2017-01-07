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
    public class NewEquipmentCard : BricksCard
    {
        public override int ResourcePrice { get; set; } = 6;

        public override void Activate(Game game)
        {
            game.CurrentPlayer.Resources.Quarry += 2;
        }
    }
}
