using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Domain.Decks
{
    public class ClassicDeckInfo : DeckInfo
    {
        public ClassicDeckInfo(string identifier, Random random)
            : base(identifier)
        {
            Random = random;
        }
        
        public Random Random { get; }
    }
}
