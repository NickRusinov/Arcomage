using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Arcomage.Domain.Players.PlayerSet;

namespace Arcomage.Domain.Actions
{
    /// <summary>
    /// Выполняет передачу хода другому игроку, в случае окончания хода текущего
    /// </summary>
    public class ReplacePlayerAction : IPlayAction
    {
        private readonly IPlayAction nextWhenReplacedPlayerAction;

        private readonly IPlayAction nextWhenNotReplacedPlayerAction;

        public ReplacePlayerAction(IPlayAction nextWhenReplacedPlayerAction, IPlayAction nextWhenNotReplacedPlayerAction)
        {
            this.nextWhenReplacedPlayerAction = nextWhenReplacedPlayerAction;
            this.nextWhenNotReplacedPlayerAction = nextWhenNotReplacedPlayerAction;
        }

        /// <inheritdoc/>
        public Task<GameResult> Play(Game game)
        {
            if (game.PlayAgain-- != 0)
                return nextWhenNotReplacedPlayerAction.Play(game);
            
            game.Players.Kind = NextPlayerKind(game.Players.Kind);

            return nextWhenReplacedPlayerAction.Play(game);
        }
    }
}
