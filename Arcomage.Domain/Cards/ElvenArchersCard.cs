using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Resources;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Эльфы-лучники"
    /// </summary>
    [Serializable]
    public class ElvenArchersCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 10;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Recruits;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            if (game.Players.CurrentPlayer.Buildings.Wall > game.Players.AdversaryPlayer.Buildings.Wall)
                game.Players.AdversaryPlayer.Buildings.Tower -= 6;
            else
                game.Players.AdversaryPlayer.Buildings.Full -= 6;
        }
    }
}
