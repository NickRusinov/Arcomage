using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arcomage.Unity.Shared.Scripts
{
    public class Reference<T>
        where T : struct
    {
        public T Value { get; set; }
    }
}