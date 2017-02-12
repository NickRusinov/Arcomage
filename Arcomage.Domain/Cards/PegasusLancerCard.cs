using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Всадник на пегасе"
    /// </summary>
    [Serializable]
    public class PegasusLancerCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 18;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Recruits;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.AdversaryPlayer.Buildings.Tower -= 12;
        }
    }
}
