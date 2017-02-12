using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Resources;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Укрепления"
    /// </summary>
    [Serializable]
    public class BattlementsCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 14;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Bricks;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.CurrentPlayer.Buildings.Wall += 7;
            game.Players.AdversaryPlayer.Buildings.Full -= 6;
        }
    }
}
