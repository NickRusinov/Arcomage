using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Resources;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Гномы-шахтеры"
    /// </summary>
    [Serializable]
    public class DwarvenMinersCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 7;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Bricks;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.CurrentPlayer.Buildings.Wall += 4;
            game.Players.CurrentPlayer.Resources.Quarry += 1;
        }
    }
}
