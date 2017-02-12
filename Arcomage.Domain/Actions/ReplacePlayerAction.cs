using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using static Arcomage.Domain.Entities.Players;

namespace Arcomage.Domain.Actions
{
    /// <summary>
    /// Выполняет передачу хода другому игроку, в случае окончания хода текущего
    /// </summary>
    public class ReplacePlayerAction : IAfterPlayAction
    {
        /// <inheritdoc/>
        public void Play(Game game, PlayResult playResult)
        {
            if (game.PlayAgain-- == 0)
                game.Players.Kind = NextPlayerKind(game.Players.Kind);
        }
    }
}
