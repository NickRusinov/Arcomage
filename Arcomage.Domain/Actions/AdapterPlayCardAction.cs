using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Threading.Tasks.TaskContinuationOptions;

namespace Arcomage.Domain.Actions
{
    /// <summary>
    /// Адаптер, преобразовывающий <see cref="IPlayCardAction"/> в <see cref="IPlayAction"/>
    /// </summary>
    public class AdapterPlayCardAction : IPlayCardAction
    {
        private readonly IPlayCardAction nextAction;

        private readonly IPlayAction playAction;

        public AdapterPlayCardAction(IPlayCardAction nextAction, IPlayAction playAction)
        {
            this.nextAction = nextAction;
            this.playAction = playAction;
        }

        /// <inheritdoc/>
        public Task Play(Game game, PlayResult playResult)
        {
            return playAction.Play(game)
                .ContinueWith(t => nextAction.Play(game, playResult), ExecuteSynchronously).Unwrap();
        }
    }
}
