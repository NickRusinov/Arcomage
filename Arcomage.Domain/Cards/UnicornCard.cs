using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Resources;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Единорог"
    /// </summary>
    [Serializable]
    public class UnicornCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 9;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Recruits;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            if (game.Players.CurrentPlayer.Resources.Magic > game.Players.AdversaryPlayer.Resources.Magic)
                game.Players.AdversaryPlayer.Buildings.Full -= 12;
            else
                game.Players.AdversaryPlayer.Buildings.Full -= 8;
        }
    }
}
