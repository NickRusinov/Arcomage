﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Resources;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Тролль-наставник"
    /// </summary>
    [Serializable]
    public class TrollTrainerCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 7;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Recruits;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.CurrentPlayer.Resources.Dungeons += 2;
        }
    }
}
