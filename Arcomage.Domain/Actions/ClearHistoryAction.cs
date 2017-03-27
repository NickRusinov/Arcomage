using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Domain.Actions
{
    /// <summary>
    /// Очищает историю хода предыдущего игрока
    /// </summary>
    public class ClearHistoryAction : IPlayAction
    {
        private readonly IPlayAction nextAction;

        public ClearHistoryAction(IPlayAction nextAction)
        {
            this.nextAction = nextAction;
        }

        /// <inheritdoc/>
        public Task<GameResult> Play(Game game)
        {
            game.History.Cards.Clear();

            return nextAction.Play(game);
        }
    }
}
