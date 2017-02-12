using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Величайшая стена"
    /// </summary>
    [Serializable]
    public class GreatWallCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 16;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Bricks;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.CurrentPlayer.Buildings.Wall += 15;
        }
    }
}
