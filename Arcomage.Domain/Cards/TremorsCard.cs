using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Resources;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Толчки"
    /// </summary>
    [Serializable]
    public class TremorsCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 7;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Bricks;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.FirstPlayer.Buildings.Wall -= 5;
            game.Players.SecondPlayer.Buildings.Wall -= 5;
            game.PlayAgain += 1;
        }
    }
}
