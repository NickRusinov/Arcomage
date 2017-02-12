using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Большая жила"
    /// </summary>
    [Serializable]
    public class MotherLodeCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 4;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Bricks;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            if (game.Players.CurrentPlayer.Resources.Quarry < game.Players.AdversaryPlayer.Resources.Quarry)
                game.Players.CurrentPlayer.Resources.Quarry += 2;
            else
                game.Players.CurrentPlayer.Resources.Quarry += 1;
        }
    }
}
