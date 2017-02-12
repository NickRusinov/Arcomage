using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Жучара"
    /// </summary>
    [Serializable]
    public class SpizzerCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 8;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Recruits;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            if (game.Players.AdversaryPlayer.Buildings.Wall == 0)
                game.Players.AdversaryPlayer.Buildings.Full -= 10;
            else
                game.Players.AdversaryPlayer.Buildings.Full -= 6;
        }
    }
}
