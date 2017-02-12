using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Resources;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Сад камней"
    /// </summary>
    [Serializable]
    public class RockGardenCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 1;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Bricks;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.CurrentPlayer.Buildings.Wall += 1;
            game.Players.CurrentPlayer.Buildings.Tower += 1;
            game.Players.CurrentPlayer.Resources.Recruits += 2;
        }
    }
}
