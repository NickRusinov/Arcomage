using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    public abstract class RecruitsCard : Card
    {
        public override bool IsEnoughResources(Resources resources)
        {
            return resources.Recruits >= ResourcePrice;
        }

        public override void PaymentResources(Resources resources)
        {
            resources.Recruits -= ResourcePrice;
        }
    }
}
