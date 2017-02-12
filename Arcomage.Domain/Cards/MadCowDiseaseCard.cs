﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Resources;

namespace Arcomage.Domain.Cards
{
    /// <summary>
    /// Игровая карта "Короыье бешенство"
    /// </summary>
    [Serializable]
    public class MadCowDiseaseCard : Card
    {
        /// <inheritdoc/>
        public override int Price { get; } = 0;

        /// <inheritdoc/>
        public override ResourceKind Kind { get; } = ResourceKind.Recruits;

        /// <inheritdoc/>
        public override void Activate(Game game)
        {
            game.Players.FirstPlayer.Resources.Recruits -= 6;
            game.Players.SecondPlayer.Resources.Recruits -= 6;
        }
    }
}
