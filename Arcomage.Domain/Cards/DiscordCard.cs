using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Раздоры"
    /// </summary>
    [Serializable]
    public class DiscordCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 5;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Gems;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.FirstPlayer.Resources.Magic -= 1;
            game.Players.SecondPlayer.Resources.Magic -= 1;
            game.Players.FirstPlayer.Buildings.Tower -= 7;
            game.Players.SecondPlayer.Buildings.Tower -= 7;
        }
    }
}
