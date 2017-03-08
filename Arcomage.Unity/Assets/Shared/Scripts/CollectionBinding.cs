using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arcomage.Unity.Shared.Scripts
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

                InvokeInit(newValueList);

                return;
            }

            if (ValueList.Count != 0 && newValueList.Count == 0)
            {
                ValueList.Clear();

                InvokeCleared();
            }

            for (var i = 0; i < newValueList.Count; i++)
            {
                if (ValueList.Count > i && !ReferenceEquals(ValueList[i], newValueList[i]))
                {
                    var oldValue = ValueList[i];
                    var newValue = newValueList[i];
                    ValueList[i] = newValue;

                    InvokeReplaced(oldValue, newValue, i);
                }

                if (ValueList.Count <= i)
                {
                    var newValue = newValueList[i];
                    ValueList.Add(newValue);

                    InvokeAdded(newValue, i);
                }
            }
        }

        private void InvokeReplaced(TValue oldValue, TValue newValue, int index)
        {
            if (Replaced != null)
                Replaced(oldValue, newValue, index);
        }

        private void InvokeAdded(TValue value, int index)
        {
            if (Added != null)
                Added.Invoke(value, index);
        }

        private void InvokeCleared()
        {
            if (Cleared != null)
                Cleared.Invoke();
        }

        private void InvokeInit(IList<TValue> newValueList)
        {
            if (Init != null)
                Init(newValueList);
        }

        public event Action<TValue, TValue, int> Replaced;

        public event Action<TValue, int> Added;

        public event Action Cleared;

        public event Action<IList<TValue>> Init;
    }
}