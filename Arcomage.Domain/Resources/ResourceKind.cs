using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arcomage.Domain.Resources
{
    /// <summary>
    /// Перечисление разновидностей ресурсов
    /// </summary>
    public enum ResourceKind
    {
        /// <summary>
        /// Руда
        /// </summary>
        Bricks,

        /// <summary>
        /// Мана
        /// </summary>
        Gems,

        /// <summary>
        /// Отряды
        /// </summary>
        Recruits,
    }
}
