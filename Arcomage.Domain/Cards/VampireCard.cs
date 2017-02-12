using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Вампир"
    /// </summary>
    [Serializable]
    public class VampireCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 17;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Recruits;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.AdversaryPlayer.Buildings.Full -= 10;
            game.Players.AdversaryPlayer.Resources.Recruits -= 5;
            game.Players.AdversaryPlayer.Resources.Dungeons -= 1;
        }
    }
}
