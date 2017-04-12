using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Players;
using static Arcomage.Domain.Players.PlayerSet;

namespace Arcomage.Domain.Actions
{
    /// <summary>
    /// Выполняет передачу хода другому игроку, в случае окончания хода текущего
    /// </summary>
    [Serializable]
    public class ReplacePlayerAction : IPlayAction
    {
        private readonly IPlayAction nextWhenReplacedPlayerAction;

        private readonly IPlayAction nextWhenNotReplacedPlayerAction;

        public ReplacePlayerAction(IPlayAction nextWhenReplacedPlayerAction, IPlayAction nextWhenNotReplacedPlayerAction)
        {
            this.nextWhenReplacedPlayerAction = nextWhenReplacedPlayerAction;
            this.nextWhenNotReplacedPlayerAction = nextWhenNotReplacedPlayerAction;
        }

        public Task<GameResult> Play(Game game, Player player, PlayResult playResult)
        {
            if (game.PlayAgain-- != 0)
                return nextWhenNotReplacedPlayerAction.Play(game, player, playResult);

            game.Players.Kind = NextPlayerKind(game.Players.Kind);

            return nextWhenReplacedPlayerAction.Play(game, player, playResult);
        }

        public bool CanPlay(Game game, Player player, PlayResult playResult)
        {
            if (game.PlayAgain - 1 != 0)
                return nextWhenNotReplacedPlayerAction.CanPlay(game, player, playResult);

            return nextWhenReplacedPlayerAction.CanPlay(game, player, playResult);
        }
    }
}
