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
    public class MoodyGoblinsCard : RecruitsCard
    {
        public override int ResourcePrice { get; set; } = 1;

        public override void Activate(Game game)
        {
            game.AdversaryPlayer.Buildings.Damage(4);
            game.CurrentPlayer.Resources.Gems -= 3;
        }
    }
}
