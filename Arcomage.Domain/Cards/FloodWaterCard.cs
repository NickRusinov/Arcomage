using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Resources;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Грунтвые воды"
    /// </summary>
    [Serializable]
    public class FloodWaterCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 6;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Bricks;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            if (game.Players.CurrentPlayer.Buildings.Wall < game.Players.AdversaryPlayer.Buildings.Wall)
            {
                game.Players.CurrentPlayer.Buildings.Tower -= 2;
                game.Players.CurrentPlayer.Resources.Dungeons -= 1;
            }
            if (game.Players.CurrentPlayer.Buildings.Wall > game.Players.AdversaryPlayer.Buildings.Wall)
            {
                game.Players.AdversaryPlayer.Buildings.Tower -= 2;
                game.Players.AdversaryPlayer.Resources.Dungeons -= 1;
            }
        }
    }
}
