using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Domain.Entities
{
    public abstract class Deck
    {
        public string Identifier { get; set; }

        public abstract Card PopCard(Game game);

        public abstract void PushCard(Game game, Card card);
    }
}
