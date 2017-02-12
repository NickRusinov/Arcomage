using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Маленькие змейки"
    /// </summary>
    [Serializable]
    public class LittleSnakesCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 6;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Recruits;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.AdversaryPlayer.Buildings.Tower -= 4;
        }
    }
}
