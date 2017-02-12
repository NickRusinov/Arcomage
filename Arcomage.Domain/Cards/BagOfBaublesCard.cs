using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Бижутерия"
    /// </summary>
    [Serializable]
    public class BagOfBaublesCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 0;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Gems;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            if (game.Players.CurrentPlayer.Buildings.Tower < game.Players.AdversaryPlayer.Buildings.Tower)
                game.Players.CurrentPlayer.Buildings.Tower += 2;
            else
                game.Players.CurrentPlayer.Buildings.Tower += 1;
        }
    }
}
