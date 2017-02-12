using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Unity.Shared.Scripts
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

                InvokeInit(value);
            }
        }

        private void InvokeInit(TValue newValue)
        {
            if (Init != null)
                Init.Invoke(newValue);
        }

        public event Action<TValue> Init;
    }
}
