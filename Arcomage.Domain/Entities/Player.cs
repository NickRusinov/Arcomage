using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Domain.Entities
{
    public abstract class Player
    {
        protected Player(Buildings buildings, Resources resources, Hand hand)
        {
            Buildings = buildings;
            Resources = resources;
            Hand = hand;
        }

        public string Identifier { get; set; }

        public Buildings Buildings { get; }

        public Resources Resources { get; }

        public Hand Hand { get; }

        public abstract Task<PlayResult> Play(Game game);
    }
}
