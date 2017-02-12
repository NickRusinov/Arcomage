using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Resources;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Гармония"
    /// </summary>
    [Serializable]
    public class HarmonicVibeCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 7;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Gems;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.CurrentPlayer.Resources.Magic += 1;
            game.Players.CurrentPlayer.Buildings.Tower += 3;
            game.Players.CurrentPlayer.Buildings.Wall += 3;
        }
    }
}
