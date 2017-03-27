using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Actions
{
    public class TerminatePlayAction : IPlayAction
    {
        public Task<GameResult> Play(Game game)
        {
            return FrameworkExtensions.FromResult(game.Rule.IsWin(game));
        }
    }
}
