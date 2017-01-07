﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    [Serializable]
    public class SuccubusCard : RecruitsCard
    {
        public override int ResourcePrice { get; set; } = 14;

        public override void Activate(Game game)
        {
            game.AdversaryPlayer.Buildings.Tower -= 5;
            game.AdversaryPlayer.Resources.Recruits -= 8;
        }
    }
}
