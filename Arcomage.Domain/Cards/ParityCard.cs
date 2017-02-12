using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Resources;
using static System.Math;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Паритет"
    /// </summary>
    [Serializable]
    public class ParityCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 7;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Gems;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            var maxMagic = Max(game.Players.CurrentPlayer.Resources.Magic, game.Players.AdversaryPlayer.Resources.Magic);

            game.Players.CurrentPlayer.Resources.Magic = maxMagic;
            game.Players.AdversaryPlayer.Resources.Magic = maxMagic;
        }
    }
}
