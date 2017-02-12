using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Domain.Rules
{
    /// <summary>
    /// Описание правил игры
    /// </summary>
    [Serializable]
    public class RuleInfo
    {
        /// <summary>
        /// Инициализирует экземпляр класса <see cref="RuleInfo"/>
        /// </summary>
        /// <param name="identifier">Идентификатор правил игры</param>
        public RuleInfo(string identifier)
        {
            Identifier = identifier;
        }

        /// <summary>
        /// Идентификатор правил игры
        /// </summary>
        public string Identifier { get; }
    }
}
