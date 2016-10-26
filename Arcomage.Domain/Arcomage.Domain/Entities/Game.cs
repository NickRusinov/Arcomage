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
        private int playAgainTurns;

        public Player FirstPlayer { get; set; }

        public Player SecondPlayer { get; set; }

        public PlayerMode PlayerMode { get; set; }

        public CardDeck CardDeck { get; set; }

        public History History { get; set; }

        public bool IsFinished { get; set; }

        public int PlayAgainTurns
        {
            get { return playAgainTurns; }
            set { playAgainTurns = Max(value, 0); }
        }
    }
}
