using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Actions
{
    /// <summary>
    /// Увеличивает значения ресурсов текущего игрока на их прирост
    /// </summary>
    public class IncreaseResourcesAction : IBeforePlayAction
    {
        /// <inheritdoc/>
        public void Play(Game game)
        {
            game.Players.CurrentPlayer.Resources.Bricks += game.Players.CurrentPlayer.Resources.Quarry;
            game.Players.CurrentPlayer.Resources.Gems += game.Players.CurrentPlayer.Resources.Magic;
            game.Players.CurrentPlayer.Resources.Recruits += game.Players.CurrentPlayer.Resources.Dungeons;
        }
    }
}
