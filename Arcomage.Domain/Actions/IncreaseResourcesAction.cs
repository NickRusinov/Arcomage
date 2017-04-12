using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Players;

namespace Arcomage.Domain.Actions
{
    /// <summary>
    /// Увеличивает значения ресурсов текущего игрока на их прирост
    /// </summary>
    [Serializable]
    public class IncreaseResourcesAction : IPlayAction
    {
        private readonly IPlayAction nextAction;

        public IncreaseResourcesAction(IPlayAction nextAction)
        {
            this.nextAction = nextAction;
        }

        public Task<GameResult> Play(Game game, Player player, PlayResult playResult)
        {
            player.Resources.Bricks += player.Resources.Quarry;
            player.Resources.Gems += player.Resources.Magic;
            player.Resources.Recruits += player.Resources.Dungeons;

            return nextAction.Play(game, player, playResult);
        }

        public bool CanPlay(Game game, Player player, PlayResult playResult)
        {
            return nextAction.CanPlay(game, player, playResult);
        }
    }
}
