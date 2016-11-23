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

        public Game(Deck deck, History history, Player firstPlayer, Player secondPlayer)
        {
            Deck = deck;
            History = history;
            FirstPlayer = firstPlayer;
            SecondPlayer = secondPlayer;
        }
        
        public Deck Deck { get; }

        public History History { get; }

        public Player FirstPlayer { get; }

        public Player SecondPlayer { get; }

        public PlayerMode PlayerMode { get; set; }

        public GameResult Result { get; set; }

        public int PlayAgain
        {
            get { return playAgain; }
            set { playAgain = Max(value, 0); }
        }
    }
}
