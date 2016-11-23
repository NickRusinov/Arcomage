using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Arcomage.Unity.Shared.Scripts
{
    public static class FrameworkExtensions
    {
        public static void Setter<T>(out T field, T value, Action onSet)
        {
            field = value;
            onSet.Invoke();
        }

        public static CultureInfo GetCultureInfoOrInvariant(string name)
        {
            return CultureInfo.GetCultures(CultureTypes.AllCultures)
                .SingleOrDefault(ci => string.Equals(ci.Name, name, StringComparison.OrdinalIgnoreCase)) ??
                CultureInfo.InvariantCulture;
        }
    }
}
