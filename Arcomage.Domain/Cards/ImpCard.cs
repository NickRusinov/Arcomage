using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Resources;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Черт"
    /// </summary>
    [Serializable]
    public class ImpCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 5;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Recruits;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.AdversaryPlayer.Buildings.Full -= 6;
            game.Players.FirstPlayer.Resources.Bricks -= 5;
            game.Players.FirstPlayer.Resources.Gems -= 5;
            game.Players.FirstPlayer.Resources.Recruits -= 5;
            game.Players.SecondPlayer.Resources.Bricks -= 5;
            game.Players.SecondPlayer.Resources.Gems -= 5;
            game.Players.SecondPlayer.Resources.Recruits -= 5;
        }
    }
}
