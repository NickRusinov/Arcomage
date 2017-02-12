using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Воитель"
    /// </summary>
    [Serializable]
    public class WarlordCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 13;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Recruits;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.AdversaryPlayer.Buildings.Full -= 13;
            game.Players.CurrentPlayer.Resources.Gems -= 3;
        }
    }
}
