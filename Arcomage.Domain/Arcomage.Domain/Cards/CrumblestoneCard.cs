﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class CrumblestoneCard : GemsCard
    {
        public override int ResourcePrice { get; set; } = 7;

        public override void Activate(Game game)
        {
            game.GetCurrentPlayer().Buildings.Tower += 5;
            game.GetAdversaryPlayer().Resources.Bricks -= 6;
        }
    }
}