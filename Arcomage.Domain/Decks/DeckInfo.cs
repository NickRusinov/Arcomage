using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Domain.Decks
{
    /// <summary>
    /// Описание колоды карт
    /// </summary>
    [Serializable]
    public abstract class DeckInfo
    {
        /// <summary>
        /// Инициализирует экземпляр класса <see cref="DeckInfo"/>
        /// </summary>
        /// <param name="identifier">Идентификатор колоды</param>
        protected DeckInfo(string identifier)
        {
            Identifier = identifier;
        }

        /// <summary>
        /// Идентификатор колоды
        /// </summary>
        public string Identifier { get; }
    }
}
