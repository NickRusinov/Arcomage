using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Затмение"
    /// </summary>
    [Serializable]
    public class SolarFlareCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 4;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Gems;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.CurrentPlayer.Buildings.Tower += 2;
            game.Players.AdversaryPlayer.Buildings.Tower -= 2;
        }
    }
}
