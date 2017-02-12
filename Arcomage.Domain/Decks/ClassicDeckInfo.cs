using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Domain.Decks
{
    /// <summary>
    /// Описание классической колоды карт
    /// </summary>
    [Serializable]
    public class ClassicDeckInfo : DeckInfo
    {
        /// <summary>
        /// Инициализирует экземпляр класса <see cref="ClassicDeckInfo"/>
        /// </summary>
        /// <param name="identifier">Идентификатор колоды</param>
        /// <param name="random">Генератор случайных чисел, используемый колодой</param>
        public ClassicDeckInfo(string identifier, Random random)
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
