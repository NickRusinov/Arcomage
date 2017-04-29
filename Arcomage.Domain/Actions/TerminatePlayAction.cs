using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Players;
using static Arcomage.Domain.Extensions;

namespace Arcomage.Domain.Actions
{
    [Serializable]
    public class TerminatePlayAction : IPlayAction
    {
        public Task<GameResult> Play(Game game, Player player, PlayResult playResult)
        {
            return FromResult(game.Rule.IsWin(game));
        }

        public bool CanPlay(Game game, Player player, PlayResult playResult)
        {
            return true;
        }
    }
}
