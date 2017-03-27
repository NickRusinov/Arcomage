using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Actions
{
    /// <summary>
    /// Выполняет проверку окончания игры
    /// </summary>
    public class FinishGameAction : IPlayAction
    {
        private readonly IPlayAction nextWhenNotFinishedGameAction;

        public FinishGameAction(IPlayAction nextWhenNotFinishedGameAction = null)
        {
            this.nextWhenNotFinishedGameAction = nextWhenNotFinishedGameAction;
        }

        /// <inheritdoc/>
        public Task<GameResult> Play(Game game)
        {
            var gameResult = game.Rule.IsWin(game);

            if (gameResult || nextWhenNotFinishedGameAction == null)
                return FrameworkExtensions.FromResult(gameResult);

            return nextWhenNotFinishedGameAction.Play(game);
        }
    }
}
