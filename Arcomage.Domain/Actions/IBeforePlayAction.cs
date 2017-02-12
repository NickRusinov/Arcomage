using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Actions
{
    /// <summary>
    /// Игровая логика, выполняемая до получения хода игроком
    /// </summary>
    public interface IBeforePlayAction
    {
        /// <summary>
        /// Выполняет действия до получения хода игроком
        /// </summary>
        /// <param name="game">Контекст игры</param>
        void Play(Game game);
    }
}
