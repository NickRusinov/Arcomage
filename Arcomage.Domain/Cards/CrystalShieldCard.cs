using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Resources;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Кристальный щит"
    /// </summary>
    [Serializable]
    public class CrystalShieldCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 12;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Gems;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.CurrentPlayer.Buildings.Tower += 8;
            game.Players.CurrentPlayer.Buildings.Wall += 3;
        }
    }
}
