using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arcomage.Unity.Framework.Bindings
{
    public sealed class CollectionBinding<TSource, TValue> : Binding
    {
        private bool init;

        private readonly TSource source;

        private readonly Func<TSource, IList<TValue>> func;

        public CollectionBinding(TSource source, Func<TSource, IList<TValue>> func)
        {
            this.source = source;
            this.func = func;
        }

        public IList<TValue> ValueList { get; private set; }

        public override void Update()
        {
            var newValueList = func.Invoke(source);

            if (!init)
            {
                init = true;
                ValueList = newValueList.ToList();

                Init?.Invoke(newValueList);

                return;
            }

            if (ValueList.Count != 0 && newValueList.Count == 0)
            {
                ValueList.Clear();

                Cleared?.Invoke();
            }

            var count = Math.Max(newValueList.Count, ValueList.Count);
            for (var i = 0; i < count; i++)
            {
                if (ValueList.Count > i && newValueList.Count > i && !Equals(ValueList[i], newValueList[i]))
                {
                    var oldValue = ValueList[i];
                    var newValue = newValueList[i];
                    ValueList[i] = newValue;

                    Replaced?.Invoke(oldValue, newValue, i);

                    continue;
                }

                if (newValueList.Count <= i)
                {
                    var oldValue = ValueList[newValueList.Count];
                    ValueList.RemoveAt(newValueList.Count);

                    Removed?.Invoke(oldValue, i);

                    continue;
                }

                if (ValueList.Count <= i)
                {
                    var newValue = newValueList[i];
                    ValueList.Add(newValue);

                    Added?.Invoke(newValue, i);

                    continue;
                }
            }
        }
        
        public event Action<TValue, TValue, int> Replaced;

        public event Action<TValue, int> Added;

        public event Action<TValue, int> Removed;

        public event Action Cleared;

        public event Action<IList<TValue>> Init;
    }
}