using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    [Serializable]
    public class RabidSheepCard : RecruitsCard
    {
        public override int ResourcePrice { get; set; } = 6;

        public override void Activate(Game game)
        {
            game.AdversaryPlayer.Buildings.Damage(6);
            game.AdversaryPlayer.Resources.Recruits -= 3;
        }
    }
}
