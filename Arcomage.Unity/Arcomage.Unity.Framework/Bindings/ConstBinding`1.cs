using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Unity.Framework.Bindings
{
    public sealed class ConstBinding<TValue> : Binding
    {
        private bool init;

        private readonly TValue value;

        public ConstBinding(TValue value)
        {
            this.value = value;
        }

        public override void Update()
        {
            if (!init)
            {
                init = true;

                Init?.Invoke(value);
            }
        }

        public event Action<TValue> Init;
    }
}
