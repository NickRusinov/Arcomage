using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arcomage.Unity.Shared.Scripts
{
    public class Binding
    {
        public static readonly Binding Instance = new Binding();

        public virtual void Update() { }
    }
}