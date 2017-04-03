using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Domain
{
    public class GameBuilder
    {
        private readonly Dictionary<KeyValuePair<Type, string>, Func<GameBuilderContext, object>> registry =
            new Dictionary<KeyValuePair<Type, string>, Func<GameBuilderContext, object>>();

        public GameBuilder Register(Type type, string key, Func<GameBuilderContext, object> factory)
        {
            var keyValuePair = new KeyValuePair<Type, string>(type, key);

            registry[keyValuePair] = factory;

            return this;
        }

        public GameBuilder Register(Type type, Func<GameBuilderContext, object> factory)
        {
            return Register(type, null, factory);
        }

        public GameBuilder Register<T>(string key, Func<GameBuilderContext, T> factory)
        {
            return Register(typeof(T), key, c => factory(c));
        }

        public GameBuilder Register<T>(Func<GameBuilderContext, T> factory)
        {
            return Register(typeof(T), null, c => factory(c));
        }

        public GameBuilderContext CreateContext()
        {
            return new GameBuilderContext(registry);
        }
    }
}
