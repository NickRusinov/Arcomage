using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Arcomage.Domain.Internal;
using static System.Threading.Tasks.TaskContinuationOptions;

namespace Arcomage.Domain.Actions
{
    /// <summary>
    /// Передает управление и ожидает выполнение хода игрока
    /// </summary>
    public class PlayPlayerAction : IPlayAction
    {
        private readonly IPlayAction nextAction;

        private readonly IPlayCardAction playCardAction;

        public PlayPlayerAction(IPlayAction nextAction, IPlayCardAction playCardAction)
        {
            this.nextAction = nextAction;
            this.playCardAction = playCardAction;
        }

        /// <inheritdoc/>
        public Task<GameResult> Play(Game game)
        {
            var cts = new CancellationTokenSource();
            
            var playTask = game.Players.CurrentPlayer.Play(game, cts.Token);
            var timerTask = game.Timer.Start(cts.Token);
            cts.CancelWhenAny(playTask, timerTask);

            return playTask.DefaultIfCancel(new PlayResult(0, false))
                .ContinueWith(t => playCardAction.Play(game, t.Result), ExecuteSynchronously).Unwrap()
                .ContinueWith(t => nextAction.Play(game), ExecuteSynchronously).Unwrap();
        }
    }
}
