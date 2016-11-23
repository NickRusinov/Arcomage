using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arcomage.Unity.Shared.Scripts
{
    public static class ObservableExtensions
    {
        public static ValueObservable<TSource, TValue> Observable<TSource, TValue>(this TSource source, Func<TSource, TValue> func, Action<TValue, TValue> onChanged, Action<TValue> onInit)
        {
            var observable = new ValueObservable<TSource, TValue>(source, func);
            observable.Changed += onChanged;
            onInit.Invoke(observable.Value);

            return observable;
        }

        public static ValueObservable<TSource, TValue> Observable<TSource, TValue>(this TSource source, Func<TSource, TValue> func, Action<TValue> onChanged, Action<TValue> onInit)
        {
            var observable = new ValueObservable<TSource, TValue>(source, func);
            observable.Changed += (old, @new) => onChanged(@new);
            onInit.Invoke(observable.Value);

            return observable;
        }

        public static ValueObservable<TSource, TValue> Observable<TSource, TValue>(this TSource source, Func<TSource, TValue> func, Action<TValue> onChangedAndInit)
        {
            var observable = new ValueObservable<TSource, TValue>(source, func);
            observable.Changed += (old, @new) => onChangedAndInit(@new);
            onChangedAndInit.Invoke(observable.Value);

            return observable;
        }

        public static ValueObservable<TSource, bool> Observable<TSource>(this TSource source, Func<TSource, bool> func, Action onChangedAndInitTrue, Action onChangedAndInitFalse)
        {
            var observable = new ValueObservable<TSource, bool>(source, func);
            observable.Changed += (old, @new) =>
            {
                if (@new)
                    onChangedAndInitTrue.Invoke();
                else
                    onChangedAndInitFalse.Invoke();
            };
        
            if (observable.Value)
                onChangedAndInitTrue.Invoke();
            else
                onChangedAndInitFalse.Invoke();

            return observable;
        }

        public static CollectionObservable<TSource, TValue> Observable<TSource, TValue>(this TSource source, Func<TSource, IList<TValue>> func, Action<TValue, TValue, int> onReplaced, Action<TValue, int> onInit)
        {
            var observable = new CollectionObservable<TSource, TValue>(source, func);
            observable.Replaced += onReplaced;

            for (var i = 0; i < observable.ValueList.Count; i++)
                onInit.Invoke(observable.ValueList[i], i);

            return observable;
        }

        public static CollectionObservable<TSource, TValue> Observable<TSource, TValue>(this TSource source, Func<TSource, IList<TValue>> func, Action<TValue, int> onAdded, Action onCleared)
        {
            var observable = new CollectionObservable<TSource, TValue>(source, func);
            observable.Added += onAdded;
            observable.Cleared += onCleared;

            return observable;
        }
    }
}