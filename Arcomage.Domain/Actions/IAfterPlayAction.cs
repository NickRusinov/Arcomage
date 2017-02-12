using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Domain.Actions
{
    /// <summary>
    /// Игровая логика, выполняемая после совершения хода игроком
    /// </summary>
    public interface IAfterPlayAction
    {
        /// <summary>
        /// Выполянет действия после совершения хода игроком
        /// </summary>
        /// <param name="game">Контекст игры</param>
        /// <param name="playResult">Ход игрока</param>
        void Play(Game game, PlayResult playResult);
    }
}
