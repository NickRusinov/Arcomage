using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arcomage.Unity.Shared.Scripts
{
    public class CollectionObservable<TSource, TValue> : Observable
    {
        private readonly TSource source;

        private readonly Func<TSource, IList<TValue>> func;

        public CollectionObservable(TSource source, Func<TSource, IList<TValue>> func)
        {
            this.source = source;
            this.func = func;

            ValueList = func.Invoke(source).ToList();
        }

        public IList<TValue> ValueList { get; private set; }

        public override void Update()
        {
            var newValueList = func.Invoke(source);

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

        protected void InvokeReplaced(TValue oldValue, TValue newValue, int index)
        {
            if (Replaced != null)
                Replaced(oldValue, newValue, index);
        }

        protected void InvokeAdded(TValue value, int index)
        {
            if (Added != null)
                Added.Invoke(value, index);
        }

        protected void InvokeCleared()
        {
            if (Cleared != null)
                Cleared.Invoke();
        }

        public event Action<TValue, TValue, int> Replaced;

        public event Action<TValue, int> Added;

        public event Action Cleared;
    }
}