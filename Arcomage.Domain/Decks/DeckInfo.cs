using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Domain.Decks
{
    public abstract class DeckInfo
    {
        protected DeckInfo(string identifier)
        {
            Identifier = identifier;
        }

        public string Identifier { get; }
    }
}
