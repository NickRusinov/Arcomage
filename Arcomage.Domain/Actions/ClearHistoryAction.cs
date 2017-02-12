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
    public class ClearHistoryAction : IBeforePlayAction
    {
        /// <inheritdoc/>
        public void Play(Game game)
        {
            game.History.Cards.Clear();
        }
    }
}
