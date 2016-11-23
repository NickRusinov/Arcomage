using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arcomage.Unity.Shared.Scripts
{
    public class ValueObservable<TSource, TValue> : Observable
    {
        private readonly TSource source;
    
        private readonly Func<TSource, TValue> func;

        public ValueObservable(TSource source, Func<TSource, TValue> func)
        {
            this.source = source;
            this.func = func;

            Value = func.Invoke(source);
        }

        public TValue Value { get; private set; }

        public override void Update()
        {
            var newValue = func.Invoke(source);

            if (!Value.Equals(newValue))
            {
                var oldValue = Value;
                Value = newValue;

                InvokeChanged(oldValue, newValue);
            }
        }

        protected virtual void InvokeChanged(TValue oldValue, TValue newValue)
        {
            if (Changed != null)
                Changed.Invoke(oldValue, newValue);
        }

        public event Action<TValue, TValue> Changed;
    }
}