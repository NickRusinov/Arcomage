using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Unity.Shared.Scripts
{
    public class DeckInfo
    {
        public string Identifier;

        public DeckInfo(string identifier)
        {
            Identifier = identifier;
        }

        public string[] GetArguments()
        {
            return new string[0];
        }
    }
}
