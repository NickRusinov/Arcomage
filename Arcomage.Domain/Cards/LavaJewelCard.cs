using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Сияющий камень"
    /// </summary>
    [Serializable]
    public class LavaJewelCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 17;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Gems;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.CurrentPlayer.Buildings.Tower += 12;
            game.Players.AdversaryPlayer.Buildings.Full -= 6;
        }
    }
}
