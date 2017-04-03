using System;
using System.Collections.Generic;

namespace Arcomage.Domain
{
    public class GameBuilderContext
    {
        private readonly Dictionary<KeyValuePair<Type, string>, object> resolved =
            new Dictionary<KeyValuePair<Type, string>, object>();

        private readonly Dictionary<KeyValuePair<Type, string>, Func<GameBuilderContext, object>> registry;

        public GameBuilderContext(Dictionary<KeyValuePair<Type, string>, Func<GameBuilderContext, object>> registry)
        {
            this.registry = registry;
        }

        public object Resolve(Type type, string key)
        {
            var keyValuePair = new KeyValuePair<Type, string>(type, key);

            if (resolved.TryGetValue(keyValuePair, out var resolvedValue))
                return resolvedValue;

            if (registry.TryGetValue(keyValuePair, out var registryValue))
                return resolved[keyValuePair] = registryValue.Invoke(this);

            throw new NotSupportedException(type.FullName);
        }

        public object Resolve(Type type)
        {
            return Resolve(type, null);
        }

        public T Resolve<T>(string key)
        {
            return (T)Resolve(typeof(T), key);
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T), null);
        }
    }
}
