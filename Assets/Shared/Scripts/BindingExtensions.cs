using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arcomage.Unity.Shared.Scripts
{
    public static class BindingExtensions
    {
        public static ValueBinding<TSource, TValue> OnChangedAndInit<TSource, TValue>(this ValueBinding<TSource, TValue> observable, Action<TValue> action)
        {
            observable.Changed += (oldValue, newValue) => action(newValue);
            observable.Init += action;

            return observable;
        }

        public static ValueBinding<TSource, TValue> OnChangedAndInit<TSource, TValue>(this ValueBinding<TSource, TValue> observable, Predicate<TValue> predicate, Action<TValue> action)
        {
            observable.Changed += (oldValue, newValue) => predicate(newValue).IfTrue(() => action(newValue));
            observable.Init += newValue => predicate(newValue).IfTrue(() => action(newValue));

            return observable;
        }

        public static CollectionBinding<TSource, TValue> OnInit<TSource, TValue>(this CollectionBinding<TSource, TValue> observable, Action<TValue, int> action)
        {
            observable.Init += newValueList => newValueList.ForEach(action);

            return observable;
        }

        public static CollectionBinding<TSource, TValue> OnReplaced<TSource, TValue>(this CollectionBinding<TSource, TValue> observable, Action<TValue, TValue, int> action)
        {
            observable.Replaced += action;

            return observable;
        }

        public static CollectionBinding<TSource, TValue> OnAdded<TSource, TValue>(this CollectionBinding<TSource, TValue> observable, Action<TValue, int> action)
        {
            observable.Added += action;

            return observable;
        }

        public static CollectionBinding<TSource, TValue> OnCleared<TSource, TValue>(this CollectionBinding<TSource, TValue> observable, Action action)
        {
            observable.Cleared += action;

            return observable;
        }
    }
}