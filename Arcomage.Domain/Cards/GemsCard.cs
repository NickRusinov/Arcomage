using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    [Serializable]
    public abstract class GemsCard : Card
    {
        public override bool IsEnoughResources(Resources resources)
        {
            return resources.Gems >= ResourcePrice;
        }

        public override void PaymentResources(Resources resources)
        {
            resources.Gems -= ResourcePrice;
        }
    }
}
