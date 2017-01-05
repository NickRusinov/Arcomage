using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;
using static System.Math;

namespace Arcomage.Domain.Cards
{
    public class ParityCard : GemsCard
    {
        public override int ResourcePrice { get; set; } = 7;

        public override void Activate(Game game)
        {
            var maxMagic = Max(game.CurrentPlayer.Resources.Magic, game.AdversaryPlayer.Resources.Magic);

            game.CurrentPlayer.Resources.Magic = maxMagic;
            game.AdversaryPlayer.Resources.Magic = maxMagic;
        }
    }
}
