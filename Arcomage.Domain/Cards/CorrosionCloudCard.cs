using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Resources;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Едкое облако"
    /// </summary>
    [Serializable]
    public class CorrosionCloudCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 11;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Recruits;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            if (game.Players.AdversaryPlayer.Buildings.Wall > 0)
                game.Players.AdversaryPlayer.Buildings.Full -= 10;
            else
                game.Players.AdversaryPlayer.Buildings.Full -= 7;
        }
    }
}
