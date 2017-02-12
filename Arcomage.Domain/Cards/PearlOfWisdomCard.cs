using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Resources;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Жемчуг мудрости"
    /// </summary>
    [Serializable]
    public class PearlOfWisdomCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 9;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Gems;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.CurrentPlayer.Buildings.Tower += 5;
            game.Players.CurrentPlayer.Resources.Magic += 1;
        }
    }
}
