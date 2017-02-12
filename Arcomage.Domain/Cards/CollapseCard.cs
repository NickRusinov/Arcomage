using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Обвал"
    /// </summary>
    [Serializable]
    public class CollapseCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 4;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Bricks;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.AdversaryPlayer.Resources.Quarry -= 1;
        }
    }
}
