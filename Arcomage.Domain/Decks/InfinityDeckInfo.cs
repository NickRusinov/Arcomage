using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Domain.Decks
{
    /// <summary>
    /// Описание бесконечной колоды карт
    /// </summary>
    [Serializable]
    public class InfinityDeckInfo : DeckInfo
    {
        /// <summary>
        /// Инициализирует экземпляр класса <see cref="InfinityDeckInfo"/>
        /// </summary>
        /// <param name="identifier">Идентификатор колоды</param>
        /// <param name="random">Генератор случайных чисел, используемый колодой</param>
        public InfinityDeckInfo(string identifier, Random random)
            : base(identifier)
        {
            Random = random;
        }

        /// <summary>
        /// Генератор случайных чисел, используемый колодой
        /// </summary>
        public Random Random { get; }
    }
}
