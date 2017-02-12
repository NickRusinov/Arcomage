using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Камнееды"
    /// </summary>
    [Serializable]
    public class RockStompersCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 11;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Recruits;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.AdversaryPlayer.Buildings.Full -= 8;
            game.Players.AdversaryPlayer.Resources.Quarry -= 1;
        }
    }
}
