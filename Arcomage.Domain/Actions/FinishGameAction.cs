using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Internal;
using Arcomage.Domain.Players;

namespace Arcomage.Domain.Actions
{
    /// <summary>
    /// Выполняет проверку окончания игры
    /// </summary>
    [Serializable]
    public class FinishGameAction : IPlayAction
    {
        private readonly IPlayAction nextWhenNotFinishedGameAction;

        public FinishGameAction(IPlayAction nextWhenNotFinishedGameAction)
        {
            this.nextWhenNotFinishedGameAction = nextWhenNotFinishedGameAction;
        }

        public Task<GameResult> Play(Game game, Player player, PlayResult playResult)
        {
            var gameResult = game.Rule.IsWin(game);
            if (gameResult)
                return FrameworkExtensions.FromResult(gameResult);

            return nextWhenNotFinishedGameAction.Play(game, player, playResult);
        }

        public bool CanPlay(Game game, Player player, PlayResult playResult)
        {
            var gameResult = game.Rule.IsWin(game);
            if (gameResult)
                return true;

            return nextWhenNotFinishedGameAction.CanPlay(game, player, playResult);
        }
    }
}
