using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Domain.Entities
{
    public abstract class Card
    {
        public string Identifier { get; set; }

        public abstract int ResourcePrice { get; set; }

        public abstract bool IsEnoughResources(Resources resources);

        public abstract void PaymentResources(Resources resources);

        public abstract void Activate(Game game);
    }
}
