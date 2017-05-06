using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Unity.Framework
{
    public static class FrameworkExtensions
    {
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
            try
            {
                return string.Format(str, args ?? new object[0]);
            }
            catch (FormatException)
            {
                return str;
            }
        }
    }
}
