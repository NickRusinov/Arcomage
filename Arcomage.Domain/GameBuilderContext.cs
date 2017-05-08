using System;
using System.Collections.Generic;

namespace Arcomage.Domain
{
    /// <summary>
    /// Представляет класс для создания объектов игровой логики в одной области
    /// </summary>
    /// <typeparam name="TState">Тип параметра для конфигурации объектов игровой логики</typeparam>
    public class GameBuilderContext<TState>
    {
        /// <summary>
        /// Список уже созданных объектов игровой логики в текущей области
        /// </summary>
        private readonly Dictionary<KeyValuePair<Type, string>, object> resolved =
            new Dictionary<KeyValuePair<Type, string>, object>();
        
        /// <summary>
        /// Хранилище зарегистрированных функций для построения объектов игровой логики
        /// </summary>
        private readonly Dictionary<KeyValuePair<Type, string>, Func<GameBuilderContext<TState>, object>> registry;
        
        /// <summary>
        /// Инициализирует экземпляр класса <see cref="GameBuilderContext{TState}"/>
        /// </summary>
        /// <param name="registry">Хранилище зарегистрированных функций для построения объектов игровой логики</param>
        /// <param name="state">Параметр для конфигурации объектов игровой логики</param>
        public GameBuilderContext(Dictionary<KeyValuePair<Type, string>, Func<GameBuilderContext<TState>, object>> registry, TState state)
        {
            this.registry = registry;
            this.State = state;
        }

        /// <summary>
        /// Параметр для конфигурации объектов игровой логики
        /// </summary>
        public TState State { get; }

        /// <summary>
        /// Получает объект игровой логики по заданному типу <paramref name="type"/> и ключу <paramref name="key"/>
        /// </summary>
        /// <param name="type">Тип получаемого объекта игровой логики</param>
        /// <param name="key">Ключ для получения объекта игровой логики</param>
        /// <returns>Объект игровой логики типа <paramref name="type"/></returns>
        /// <exception cref="InvalidOperationException">
        /// Отсутствует регистрация объекта игровой логики с типом <paramref name="type"/> и ключом 
        /// <paramref name="key"/>
        /// </exception>
        public object Resolve(Type type, string key)
        {
            var keyValuePair = new KeyValuePair<Type, string>(type, key);

            if (resolved.TryGetValue(keyValuePair, out var resolvedValue))
                return resolvedValue;

            if (registry.TryGetValue(keyValuePair, out var registryValue))
                return resolved[keyValuePair] = registryValue.Invoke(this);

            throw new InvalidOperationException(type.FullName);
        }

        /// <summary>
        /// Получает объект игровой логики по заданному типу <paramref name="type"/> и ключом по умолчанию
        /// </summary>
        /// <param name="type">Тип получаемого объекта игровой логики</param>
        /// <returns>Объект игровой логики типа <paramref name="type"/></returns>
        /// <exception cref="InvalidOperationException">
        /// Отсутствует регистрация объекта игровой логики с типом <paramref name="type"/> и ключом по умолчанию
        /// </exception>
        public object Resolve(Type type)
        {
            return Resolve(type, null);
        }

        /// <summary>
        /// Получает объект игровой логики по заданному типу <typeparamref name="T"/> и ключом <paramref name="key"/>
        /// </summary>
        /// <typeparam name="T">Тип получаемого объекта игровой логики</typeparam>
        /// <param name="key">Ключ для получения объекта игровой логики</param>
        /// <returns>Объект игровой логики</returns>
        /// <exception cref="InvalidOperationException">
        /// Отсутствует регистрация объекта игровой логики с типом <typeparamref name="T"/> и ключом 
        /// <paramref name="key"/>
        /// </exception>
        public T Resolve<T>(string key)
        {
            return (T)Resolve(typeof(T), key);
        }

        /// <summary>
        /// Получает объект игровой логики по заданному типу <typeparamref name="T"/> и ключом по умолчанию
        /// </summary>
        /// <typeparam name="T">Тип получаемого объекта игровой логики</typeparam>
        /// <returns>Объект игровой логики</returns>
        /// <exception cref="InvalidOperationException">
        /// Отсутствует регистрация объекта игровой логики с типом <typeparamref name="T"/> и ключом по умолчанию
        /// </exception>
        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T), null);
        }
    }
}
