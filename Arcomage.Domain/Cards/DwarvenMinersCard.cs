﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class DwarvenMinersCard : BricksCard
    {
        public override int ResourcePrice { get; set; } = 7;

        public override void Activate(Game game)
        {
            game.CurrentPlayer.Buildings.Wall += 4;
            game.CurrentPlayer.Resources.Quarry += 1;
        }
    }
}
