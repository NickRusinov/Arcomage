using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Domain.Rules
{
    public class RuleInfo
    {
        public RuleInfo(string identifier)
        {
            Identifier = identifier;
        }

        public string Identifier { get; }
    }
}
