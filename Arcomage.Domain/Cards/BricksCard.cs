using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    [Serializable]
    public abstract class BricksCard : Card
    {
        public override bool IsEnoughResources(Resources resources)
        {
            return resources.Bricks >= ResourcePrice;
        }

        public override void PaymentResources(Resources resources)
        {
            resources.Bricks -= ResourcePrice;
        }
    }
}
