using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Счастливая монетка"
    /// </summary>
    [Serializable]
    public class LuckyCacheCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 0;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Bricks;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.CurrentPlayer.Resources.Bricks += 2;
            game.Players.CurrentPlayer.Resources.Gems += 2;
            game.PlayAgain += 1;
        }
    }
}
