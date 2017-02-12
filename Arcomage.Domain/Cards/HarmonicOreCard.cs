using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Поющий уголь"
    /// </summary>
    [Serializable]
    public class HarmonicOreCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 11;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Bricks;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.CurrentPlayer.Buildings.Wall += 6;
            game.Players.CurrentPlayer.Buildings.Tower += 3;
        }
    }
}
