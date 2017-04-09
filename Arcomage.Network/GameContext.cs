using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Network
{
    public class GameContext
    {
        public Guid Id { get; set; }

        public GameState State { get; set; }

        public UserContext FirstUser { get; set; }

        public UserContext SecondUser { get; set; }
    }
}
