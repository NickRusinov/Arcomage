using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Огненный рубин"
    /// </summary>
    [Serializable]
    public class FireRubyCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 13;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Gems;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.CurrentPlayer.Buildings.Tower += 6;
            game.Players.AdversaryPlayer.Buildings.Tower -= 4;
        }
    }
}
