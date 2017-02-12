using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Благодатная почва"
    /// </summary>
    [Serializable]
    public class FriendlyTerrainCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 1;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Bricks;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.CurrentPlayer.Buildings.Wall += 1;
            game.PlayAgain += 1;
        }
    }
}
