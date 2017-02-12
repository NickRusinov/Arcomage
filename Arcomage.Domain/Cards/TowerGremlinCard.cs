using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Гремлин в башне"
    /// </summary>
    [Serializable]
    public class TowerGremlinCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 8;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Recruits;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.AdversaryPlayer.Buildings.Full -= 2;
            game.Players.CurrentPlayer.Buildings.Wall += 4;
            game.Players.CurrentPlayer.Buildings.Tower += 2;
        }
    }
}
