using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Domain.Entities
{
    public abstract class Player : IIdentifiable
    {
        public string Identifier { get; set; }

        public Buildings Buildings { get; set; }

        public Resources Resources { get; set; }

        public CardSet CardSet { get; set; }

        public abstract void Play(Game game);
    }
}
