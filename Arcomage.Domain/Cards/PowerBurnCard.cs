using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Взрыв силы"
    /// </summary>
    [Serializable]
    public class PowerBurnCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 3;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Gems;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.CurrentPlayer.Buildings.Tower -= 5;
            game.Players.CurrentPlayer.Resources.Magic += 2;
        }
    }
}
