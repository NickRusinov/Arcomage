using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Domain.Entities
{
    public class Game
    {
        public Player FirstPlayer { get; set; }

        public Player SecondPlayer { get; set; }

        public PlayerMode PlayerMode { get; set; }

        public CardDeck CardDeck { get; set; }
    }
}
