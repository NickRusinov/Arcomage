using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Кварц"
    /// </summary>
    [Serializable]
    public class QuartzCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 1;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Gems;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.CurrentPlayer.Buildings.Tower += 1;
            game.PlayAgain += 1;
        }
    }
}
