using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Resources;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Обвал рудника"
    /// </summary>
    [Serializable]
    public class StripMineCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 0;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Bricks;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.CurrentPlayer.Resources.Quarry -= 1;
            game.Players.CurrentPlayer.Buildings.Wall += 10;
            game.Players.CurrentPlayer.Resources.Gems += 5;
        }
    }
}
