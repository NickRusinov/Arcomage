using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arcomage.Unity.Framework.Bindings
{
    public sealed class ValueBinding<TValue> : Binding
    {
        private bool init;

        private readonly Func<TValue> func;

        public ValueBinding(Func<TValue> func)
        {
            this.func = func;
        }

        public TValue Value { get; private set; }

        public override void Update()
        {
            var newValue = func.Invoke();

            if (!init)
            {
                init = true;
                Value = newValue;

                Init?.Invoke(newValue);

                return;
            }

            if (!Equals(Value, newValue))
            {
                var oldValue = Value;
                Value = newValue;

                Changed?.Invoke(oldValue, newValue);
            }
        }

        public event Action<TValue, TValue> Changed;

        public event Action<TValue> Init;
    }
}
