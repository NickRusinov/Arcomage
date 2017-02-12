using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Полнолуние"
    /// </summary>
    [Serializable]
    public class FullMoonCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 0;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Recruits;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.FirstPlayer.Resources.Dungeons += 1;
            game.Players.SecondPlayer.Resources.Dungeons += 1;
            game.Players.CurrentPlayer.Resources.Recruits += 3;
        }
    }
}
