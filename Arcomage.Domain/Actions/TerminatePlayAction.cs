using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Internal;
using Arcomage.Domain.Players;

namespace Arcomage.Domain.Actions
{
    public class TerminatePlayAction : IPlayAction
    {
        public Task<GameResult> Play(Game game, Player player, PlayResult playResult)
        {
            return FrameworkExtensions.FromResult(game.Rule.IsWin(game));
        }

        public bool CanPlay(Game game, Player player, PlayResult playResult)
        {
            return true;
        }
    }
}
