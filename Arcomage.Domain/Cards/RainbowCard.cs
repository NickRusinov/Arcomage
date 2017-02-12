using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Радуга"
    /// </summary>
    [Serializable]
    public class RainbowCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 0;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Gems;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.FirstPlayer.Buildings.Tower += 1;
            game.Players.SecondPlayer.Buildings.Tower += 1;
            game.Players.CurrentPlayer.Resources.Gems += 3;
        }
    }
}
