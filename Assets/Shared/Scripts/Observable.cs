using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arcomage.Unity.Shared.Scripts
{
    public class Observable
    {
        public static readonly Observable Instance = new Observable();

        public virtual void Update() { }
    }
}