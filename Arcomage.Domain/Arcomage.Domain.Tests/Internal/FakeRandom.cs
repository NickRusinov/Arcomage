using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Domain.Tests.Internal
{
    internal class FakeRandom : Random
    {
        public int NextGenerate { get; set; }

        public override int Next(int maxValue)
        {
            return NextGenerate % maxValue;
        }
    }
}
