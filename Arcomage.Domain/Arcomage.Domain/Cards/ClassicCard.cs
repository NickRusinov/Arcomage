using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    public abstract class ClassicCard : Card
    {
        protected ClassicCard(string identifier, int resourcePrice, ResourceMode resourceMode)
        {
            Identifier = identifier;
            ResourcePrice = resourcePrice;
            ResourceMode = resourceMode;
        }
        
        public override void Activate(Game game)
        {
            game.PlayerMode = (PlayerMode)((int)(game.PlayerMode + 1) % 2);
        }
    }
}
