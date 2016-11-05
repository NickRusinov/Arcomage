using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Arcomage.Domain.Entities
{
    public class Game
    {
        private int playAgain;

        public Player FirstPlayer { get; set; }

        public Player SecondPlayer { get; set; }

        public PlayerMode PlayerMode { get; set; }

        public Deck Deck { get; set; }

        public History History { get; set; }

        public GameResult Result { get; set; }

        public int PlayAgain
        {
            get { return playAgain; }
            set { playAgain = Max(value, 0); }
        }
    }
}
