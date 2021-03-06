﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Resources;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Монастырь"
    /// </summary>
    [Serializable]
    public class SanctuaryCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 15;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Gems;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.CurrentPlayer.Buildings.Tower += 10;
            game.Players.CurrentPlayer.Buildings.Wall += 5;
            game.Players.CurrentPlayer.Resources.Recruits += 5;
        }
    }
}
