using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arcomage.Unity.Shared.Scripts
{
    public sealed class ValueBinding<TSource, TValue> : Binding
    {
        private bool init;

        private readonly TSource source;

        private readonly Func<TSource, TValue> func;

        public ValueBinding(TSource source, Func<TSource, TValue> func)
        {
            this.source = source;
            this.func = func;
        }

        public TValue Value { get; private set; }

        public override void Update()
        {
            var newValue = func.Invoke(source);

            if (!init)
            {
                init = true;
                Value = newValue;

                InvokeInit(newValue);

                return;
            }

            if (!Equals(Value, newValue))
            {
                var oldValue = Value;
                Value = newValue;

                InvokeChanged(oldValue, newValue);
            }
        }

        private void InvokeChanged(TValue oldValue, TValue newValue)
        {
            if (Changed != null)
                Changed.Invoke(oldValue, newValue);
        }

        private void InvokeInit(TValue newValue)
        {
            if (Init != null)
                Init.Invoke(newValue);
        } 

        public event Action<TValue, TValue> Changed;

        public event Action<TValue> Init;
    }
}
