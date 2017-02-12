using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Resources;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Матрица"
    /// </summary>
    [Serializable]
    public class CrystalMatrixCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 6;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Gems;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.CurrentPlayer.Resources.Magic += 1;
            game.Players.CurrentPlayer.Buildings.Tower += 3;
            game.Players.AdversaryPlayer.Buildings.Tower += 1;
        }
    }
}
