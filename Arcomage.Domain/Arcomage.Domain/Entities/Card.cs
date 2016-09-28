using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Domain.Entities
{
    public abstract class Card : IIdentifiable, IActivable
    {
        public string Identifier { get; set; }

        public int ResourcePrice { get; set; }

        public ResourceMode ResourceMode { get; set; }

        public abstract void Activate(Game game);
    }
}
