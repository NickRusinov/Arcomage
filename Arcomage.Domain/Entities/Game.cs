using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Arcomage.Domain.Entities
{
    [Serializable]
    public class Game
    {
        private int playAgain;

        private int discardOnly;

        public Game(Deck deck, History history, Player firstPlayer, Player secondPlayer)
        {
            Deck = deck;
            History = history;
            FirstPlayer = firstPlayer;
            SecondPlayer = secondPlayer;
            CurrentPlayer = firstPlayer;
            AdversaryPlayer = secondPlayer;
        }
        
        public Deck Deck { get; }

        public History History { get; }

        public Player FirstPlayer { get; }

        public Player SecondPlayer { get; }

        public Player CurrentPlayer { get; private set; }

        public Player AdversaryPlayer { get; private set; }

        public Player PreviousPlayer { get; set; }

        public GameResult Result { get; set; }

        public int PlayAgain
        {
            get { return playAgain; }
            set { playAgain = Max(value, 0); }
        }

        public int DiscardOnly
        {
            get { return discardOnly; }
            set { discardOnly = Max(value, 0); }
        }

        public void SwapPlayer()
        {
            var oldCurrentPlayer = CurrentPlayer;
            var oldAdversaryPlayer = AdversaryPlayer;

            CurrentPlayer = oldAdversaryPlayer;
            AdversaryPlayer = oldCurrentPlayer;
        }
    }
}
