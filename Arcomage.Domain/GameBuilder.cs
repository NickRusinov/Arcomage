using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Domain
{
    /// <summary>
    /// Строитель, предназначенный для построения объектов игровой логики
    /// </summary>
    /// <typeparam name="TState">Тип параметра для конфигурации объектов игровой логики</typeparam>
    public class GameBuilder<TState>
    {
        /// <summary>
        /// Хранилище зарегистрированных функций для построения объектов игровой логики
        /// </summary>
        private readonly Dictionary<KeyValuePair<Type, string>, Func<GameBuilderContext<TState>, object>> registry =
            new Dictionary<KeyValuePair<Type, string>, Func<GameBuilderContext<TState>, object>>();

        /// <summary>
        /// Регистрирует функцию для построения объекта игровой логики <paramref name="factory"/> с типом 
        /// <paramref name="type"/>и ключом <paramref name="type"/>
        /// </summary>
        /// <param name="type">Тип регистрируемого объекта игровой логики</param>
        /// <param name="key">Ключ для регистрации объекта игровой логики</param>
        /// <param name="factory">Функция для построения объекта игровой логики</param>
        /// <returns>Текущий строитель</returns>
        public GameBuilder<TState> Register(Type type, string key, Func<GameBuilderContext<TState>, object> factory)
        {
            var keyValuePair = new KeyValuePair<Type, string>(type, key);

            registry[keyValuePair] = factory;

            return this;
        }

        /// <summary>
        /// Региструет функцию для построения объекта игровой логики <paramref name="factory"/> с типом 
        /// <paramref name="type"/> и ключом по умолчанию
        /// </summary>
        /// <param name="type">Тип регистрируемого объекта игровой логики</param>
        /// <param name="factory">Функция для построения объекта игровой логики</param>
        /// <returns>Текущий строитель</returns>
        public GameBuilder<TState> Register(Type type, Func<GameBuilderContext<TState>, object> factory)
        {
            return Register(type, null, factory);
        }

        /// <summary>
        /// Регистрирует функцию для построения объекта игровой логики <paramref name="factory"/> с типом
        /// <typeparamref name="T"/> и ключом <paramref name="key"/>
        /// </summary>
        /// <typeparam name="T">Тип регистрируемого объекта игровой логики</typeparam>
        /// <param name="key">Ключ для регистрации объекта игровой логики</param>
        /// <param name="factory">Функция для построения объекта игровой логики</param>
        /// <returns>Текущий строитель</returns>
        public GameBuilder<TState> Register<T>(string key, Func<GameBuilderContext<TState>, T> factory)
        {
            return Register(typeof(T), key, c => factory(c));
        }

        /// <summary>
        /// Регистрирует функцию для построения объекта игровой логики <paramref name="factory"/> с типом
        /// <typeparamref name="T"/> и ключом по умолчанию
        /// </summary>
        /// <typeparam name="T">Тип регистрируемого объекта игровой логики</typeparam>
        /// <param name="factory">Функция для построения объекта игровой логики</param>
        /// <returns>Текущий строитель</returns>
        public GameBuilder<TState> Register<T>(Func<GameBuilderContext<TState>, T> factory)
        {
            return Register(typeof(T), null, c => factory(c));
        }

        /// <summary>
        /// Создает экземпляр класса для создания объектов игровой логики в одной области
        /// </summary>
        /// <param name="state">Параметр для конфигурации объектов игровой логики</param>
        /// <returns>Экземпляр класса для создания объектов игровой логики в одной области</returns>
        public GameBuilderContext<TState> CreateContext(TState state)
        {
            return new GameBuilderContext<TState>(registry, state);
        }
    }
}
