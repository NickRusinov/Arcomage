using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Дракон"
    /// </summary>
    [Serializable]
    public class DragonCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 25;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Recruits;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.AdversaryPlayer.Buildings.Full -= 20;
            game.Players.AdversaryPlayer.Resources.Gems -= 10;
            game.Players.AdversaryPlayer.Resources.Dungeons -= 1;
        }
    }
}
