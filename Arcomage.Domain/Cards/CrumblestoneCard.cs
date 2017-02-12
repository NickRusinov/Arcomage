using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Resources;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Мягкий камень"
    /// </summary>
    [Serializable]
    public class CrumblestoneCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 7;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Gems;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.CurrentPlayer.Buildings.Tower += 5;
            game.Players.AdversaryPlayer.Resources.Bricks -= 6;
        }
    }
}
