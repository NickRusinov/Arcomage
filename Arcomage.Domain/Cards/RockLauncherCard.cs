using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Resources;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Скаломет"
    /// </summary>
    [Serializable]
    public class RockLauncherCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 18;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Bricks;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.CurrentPlayer.Buildings.Wall += 6;
            game.Players.AdversaryPlayer.Buildings.Full -= 10;
        }
    }
}
