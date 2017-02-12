using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Resources;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Медитизм"
    /// </summary>
    [Serializable]
    public class PhaseJewelCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 18;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Gems;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.CurrentPlayer.Buildings.Tower += 13;
            game.Players.CurrentPlayer.Resources.Recruits += 6;
            game.Players.CurrentPlayer.Resources.Bricks += 6;
        }
    }
}
