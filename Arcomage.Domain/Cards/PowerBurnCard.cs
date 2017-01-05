﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class PowerBurnCard : GemsCard
    {
        public override int ResourcePrice { get; set; } = 3;

        public override void Activate(Game game)
        {
            game.CurrentPlayer.Buildings.Tower -= 5;
            game.CurrentPlayer.Resources.Magic += 2;
        }
    }
}
