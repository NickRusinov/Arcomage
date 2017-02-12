using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Resources;
using static System.Math;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Вор"
    /// </summary>
    [Serializable]
    public class ThiefCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 12;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Recruits;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            var oldBricks = game.Players.AdversaryPlayer.Resources.Bricks;
            var oldGems = game.Players.AdversaryPlayer.Resources.Gems;

            game.Players.AdversaryPlayer.Resources.Bricks -= 5;
            game.Players.AdversaryPlayer.Resources.Gems -= 10;
            game.Players.CurrentPlayer.Resources.Bricks += Min(5, oldBricks) / 2;
            game.Players.CurrentPlayer.Resources.Gems += Min(10, oldGems) / 2;
        }
    }
}
