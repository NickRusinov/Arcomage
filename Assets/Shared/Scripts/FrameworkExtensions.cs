using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Arcomage.Unity.Shared.Scripts
{
    public static class FrameworkExtensions
    {
        public static bool IfTrue(this bool boolean, Action action)
        {
            if (boolean)
                action();

            return boolean;
        }

        public static bool IfFalse(this bool boolean, Action action)
        {
            if (!boolean)
                action();

            return boolean;
        }

        public static T Try<T>(Func<T> func, T def = default(T))
        {
            try
            {
                return func();
            }
            catch
            {
                return def;
            }
        }

        public static ICollection<T> ForEach<T>(this ICollection<T> collection, Action<T> action)
        {
            foreach (var item in collection)
                action.Invoke(item);

            return collection;
        }

        public static ICollection<T> ForEach<T>(this ICollection<T> collection, Action<T, int> action)
        {
            var index = 0;
            foreach (var item in collection)
                action.Invoke(item, index++);

            return collection;
        }

        public static string TryFormat(this string str, params string[] args)
        {
            return Try(() => string.Format(str, args), str);
        }
    }
}
