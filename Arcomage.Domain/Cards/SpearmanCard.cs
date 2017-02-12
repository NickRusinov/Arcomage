using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Копейщик"
    /// </summary>
    [Serializable]
    public class SpearmanCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 2;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Recruits;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            if (game.Players.CurrentPlayer.Buildings.Wall > game.Players.AdversaryPlayer.Buildings.Wall)
                game.Players.AdversaryPlayer.Buildings.Full -= 3;
            else
                game.Players.AdversaryPlayer.Buildings.Full -= 2;
        }
    }
}
