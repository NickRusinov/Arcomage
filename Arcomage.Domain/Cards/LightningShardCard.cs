using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Resources;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Молния"
    /// </summary>
    [Serializable]
    public class LightningShardCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 11;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Gems;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            if (game.Players.CurrentPlayer.Buildings.Tower > game.Players.AdversaryPlayer.Buildings.Wall)
            {
                game.Players.AdversaryPlayer.Buildings.Tower -= 8;
            }
            else
            {
                game.Players.FirstPlayer.Buildings.Full -= 8;
                game.Players.SecondPlayer.Buildings.Full -= 8;
            }
        }
    }
}
