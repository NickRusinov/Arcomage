using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Resources;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Эмпатия"
    /// </summary>
    [Serializable]
    public class EmpathyGemCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 14;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Gems;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.CurrentPlayer.Buildings.Tower += 8;
            game.Players.CurrentPlayer.Resources.Dungeons += 1;
        }
    }
}
