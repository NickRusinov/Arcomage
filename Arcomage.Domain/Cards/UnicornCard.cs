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
    public class UnicornCard : RecruitsCard
    {
        public override int ResourcePrice { get; set; } = 9;

        public override void Activate(Game game)
        {
            if (game.CurrentPlayer.Resources.Magic > game.AdversaryPlayer.Resources.Magic)
                game.AdversaryPlayer.Buildings.Damage(12);
            else
                game.AdversaryPlayer.Buildings.Damage(8);
        }
    }
}
