using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Новые успехи"
    /// </summary>
    [Serializable]
    public class FocusedDesignsCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 15;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Bricks;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.CurrentPlayer.Buildings.Wall += 8;
            game.Players.CurrentPlayer.Buildings.Tower += 5;
        }
    }
}
