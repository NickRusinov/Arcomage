using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Resources;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Гоблины"
    /// </summary>
    [Serializable]
    public class MoodyGoblinsCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 1;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Recruits;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.AdversaryPlayer.Buildings.Full -= 4;
            game.Players.CurrentPlayer.Resources.Gems -= 3;
        }
    }
}
