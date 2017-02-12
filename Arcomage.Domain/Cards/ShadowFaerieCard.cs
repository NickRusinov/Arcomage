using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Призрачная фея"
    /// </summary>
    [Serializable]
    public class ShadowFaerieCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 6;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Recruits;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.AdversaryPlayer.Buildings.Tower -= 2;
            game.PlayAgain += 1;
        }
    }
}
