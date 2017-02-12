using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Казармы"
    /// </summary>
    [Serializable]
    public class BarracksCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 10;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Bricks;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.CurrentPlayer.Buildings.Wall += 6;
            game.Players.CurrentPlayer.Resources.Recruits += 6;

            if (game.Players.CurrentPlayer.Resources.Dungeons < game.Players.AdversaryPlayer.Resources.Dungeons)
                game.Players.CurrentPlayer.Resources.Dungeons += 1;
        }
    }
}
