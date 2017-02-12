using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Resources;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Галереи"
    /// </summary>
    [Serializable]
    public class PorticulusCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 9;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Bricks;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.CurrentPlayer.Buildings.Wall += 5;
            game.Players.CurrentPlayer.Resources.Dungeons += 1;
        }
    }
}
