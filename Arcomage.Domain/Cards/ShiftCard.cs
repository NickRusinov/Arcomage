using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Resources;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Сдвиг"
    /// </summary>
    [Serializable]
    public class ShiftCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 17;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Bricks;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            var currentWall = game.Players.CurrentPlayer.Buildings.Wall;
            var adversaryWall = game.Players.AdversaryPlayer.Buildings.Wall;

            game.Players.CurrentPlayer.Buildings.Wall = adversaryWall;
            game.Players.AdversaryPlayer.Buildings.Wall = currentWall;
        }
    }
}
