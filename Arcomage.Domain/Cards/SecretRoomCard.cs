using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Resources;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Секретная пещера"
    /// </summary>
    [Serializable]
    public class SecretRoomCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 8;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Bricks;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.CurrentPlayer.Resources.Magic += 1;
            game.PlayAgain += 1;
        }
    }
}
