using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arcomage.Unity.Shared.Scripts
{
    public static class BindingExtensions
    {
        public static ValueBinding<TSource, TValue> OnChangedAndInit<TSource, TValue>(this ValueBinding<TSource, TValue> binding, Action<TValue> action)
        {
            binding.Changed += (oldValue, newValue) => action(newValue);
            binding.Init += action;

            return binding;
        }

        public static ValueBinding<TSource, TValue> OnChangedAndInit<TSource, TValue>(this ValueBinding<TSource, TValue> binding, Predicate<TValue> predicate, Action<TValue> action)
        {
            binding.Changed += (oldValue, newValue) => predicate(newValue).IfTrue(() => action(newValue));
            binding.Init += newValue => predicate(newValue).IfTrue(() => action(newValue));

            return binding;
        }

        public static ValueBinding<TSource, TValue> OnChanged<TSource, TValue>(this ValueBinding<TSource, TValue> binding, Action<TValue> action)
        {
            binding.Changed += (oldValue, newValue) => action(newValue);

            return binding;
        }

        public static CollectionBinding<TSource, TValue> OnInit<TSource, TValue>(this CollectionBinding<TSource, TValue> binding, Action<TValue, int> action)
        {
            binding.Init += newValueList => newValueList.ForEach(action);

            return binding;
        }

        public static CollectionBinding<TSource, TValue> OnReplaced<TSource, TValue>(this CollectionBinding<TSource, TValue> binding, Action<TValue, TValue, int> action)
        {
            binding.Replaced += action;

            return binding;
        }

        public static CollectionBinding<TSource, TValue> OnAdded<TSource, TValue>(this CollectionBinding<TSource, TValue> binding, Action<TValue, int> action)
        {
            binding.Added += action;

            return binding;
        }

        public static CollectionBinding<TSource, TValue> OnCleared<TSource, TValue>(this CollectionBinding<TSource, TValue> binding, Action action)
        {
            binding.Cleared += action;

            return binding;
        }
    }
}