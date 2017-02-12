using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Сверхурочные"
    /// </summary>
    [Serializable]
    public class WorkOvertimeCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 2;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Bricks;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.CurrentPlayer.Buildings.Wall += 5;
            game.Players.CurrentPlayer.Resources.Gems -= 6;
        }
    }
}
