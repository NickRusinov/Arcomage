﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    public class WarlordCard : RecruitsCard
    {
        public override int ResourcePrice { get; set; } = 13;

        public override void Activate(Game game)
        {
            game.AdversaryPlayer.Buildings.Damage(13);
            game.CurrentPlayer.Resources.Gems -= 3;
        }
    }
}
