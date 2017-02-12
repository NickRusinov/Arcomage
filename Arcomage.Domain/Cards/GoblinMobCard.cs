using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Resources;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Армия гоблинов"
    /// </summary>
    [Serializable]
    public class GoblinMobCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 3;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Recruits;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.AdversaryPlayer.Buildings.Full -= 6;
            game.Players.CurrentPlayer.Buildings.Full -= 3;
        }
    }
}
