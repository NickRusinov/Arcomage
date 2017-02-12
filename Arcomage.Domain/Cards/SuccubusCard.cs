using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Суккубы"
    /// </summary>
    [Serializable]
    public class SuccubusCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 14;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Recruits;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.AdversaryPlayer.Buildings.Tower -= 5;
            game.Players.AdversaryPlayer.Resources.Recruits -= 8;
        }
    }
}
