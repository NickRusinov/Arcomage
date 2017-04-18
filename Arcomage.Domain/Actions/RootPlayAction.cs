using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Arcomage.Domain.Internal;
using Arcomage.Domain.Players;

namespace Arcomage.Domain.Actions
{
    [Serializable]
    public class RootPlayAction : IPlayAction
    {
        private readonly IPlayAction nextAction;

        private int isInit = 0;

        public RootPlayAction(IPlayAction nextAction)
        {
            this.nextAction = nextAction;
        }

        public async Task<GameResult> WaitPlay(Game game)
        {
            if (Interlocked.Exchange(ref isInit, 1) == 0)
            {
                var player = game.Players.CurrentPlayer;
                player.Resources.Bricks += player.Resources.Quarry;
                player.Resources.Gems += player.Resources.Magic;
                player.Resources.Recruits += player.Resources.Dungeons;
            }

            var cts = new CancellationTokenSource();

            var playTask = game.Players.CurrentPlayer.Play(game, cts.Token);
            var timerTask = game.Timer.Start(cts.Token);
            await cts.CancelWhenAny(playTask, timerTask);

            var playResult = playTask.DefaultIfCancel(new PlayResult(0, false)).GetAwaiter().GetResult();
            var gameResult = Play(game, game.Players.CurrentPlayer, playResult).GetAwaiter().GetResult();

            return gameResult;
        }

        public async Task<GameResult> Play(Game game, Player player, PlayResult playResult)
        {
            if (nextAction.CanPlay(game, player, playResult))
                return await nextAction.Play(game, player, playResult);

            return game.Rule.IsWin(game);
        }

        public bool CanPlay(Game game, Player player, PlayResult playResult)
        {
            return nextAction.CanPlay(game, player, playResult);
        }
    }
}
