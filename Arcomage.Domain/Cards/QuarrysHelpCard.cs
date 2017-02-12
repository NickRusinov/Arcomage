using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Помощь в работе"
    /// </summary>
    [Serializable]
    public class QuarrysHelpCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 4;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Gems;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.CurrentPlayer.Buildings.Tower += 7;
            game.Players.CurrentPlayer.Resources.Bricks -= 10;
        }
    }
}
