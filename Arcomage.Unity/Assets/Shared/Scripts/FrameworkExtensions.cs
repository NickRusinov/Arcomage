using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using SmartLocalization;

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

        public static TSource Do<TSource>(this TSource source, Action<TSource> action)
        {
            if (source != null)
                action.Invoke(source);

            return default(TSource);
        }

        public static TResult Do<TSource, TResult>(this TSource source, Func<TSource, TResult> func)
        {
            if (source != null)
                return func.Invoke(source);

            return default(TResult);
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
            try
            {
                return string.Format(str, args ?? new object[0]);
            }
            catch (FormatException)
            {
                return str;
            }
        }

        public static string TryGetTextValue(this LanguageManager manager, string key)
        {
            return manager.GetTextValue(key) ?? key;
        }
    }
}
