using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Фундамент"
    /// </summary>
    [Serializable]
    public class FoundationsCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 3;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Bricks;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            if (game.Players.CurrentPlayer.Buildings.Wall == 0)
                game.Players.CurrentPlayer.Buildings.Wall += 6;
            else
                game.Players.CurrentPlayer.Buildings.Wall += 3;
        }
    }
}
