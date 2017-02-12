using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Вступление"
    /// </summary>
    [Serializable]
    public class ApprenticeCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 5;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Gems;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.CurrentPlayer.Buildings.Tower += 4;
            game.Players.CurrentPlayer.Resources.Recruits -= 3;
            game.Players.AdversaryPlayer.Buildings.Tower -= 2;
        }
    }
}
