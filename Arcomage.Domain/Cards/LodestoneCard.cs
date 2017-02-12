using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Рудная жила"
    /// </summary>
    [Serializable]
    public class LodestoneCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 5;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Gems;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.CurrentPlayer.Buildings.Tower += 8;
        }
    }
}
