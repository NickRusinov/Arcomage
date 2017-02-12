using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Resources;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Сердце дракона"
    /// </summary>
    [Serializable]
    public class DragonsHeartCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 24;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Bricks;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.CurrentPlayer.Buildings.Wall += 20;
            game.Players.CurrentPlayer.Buildings.Tower += 8;
        }
    }
}
