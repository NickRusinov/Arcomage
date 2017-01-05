﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class QuarrysHelpCard : GemsCard
    {
        public override int ResourcePrice { get; set; } = 4;

        public override void Activate(Game game)
        {
            game.CurrentPlayer.Buildings.Tower += 7;
            game.CurrentPlayer.Resources.Bricks -= 10;
        }
    }
}
