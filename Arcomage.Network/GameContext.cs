using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Network
{
    public class GameContext
    {
        public GameContext()
        {
        }

        public GameContext(Guid id, UserContext firstUser, UserContext secondUser)
        {
            Id = id;
            FirstUser = firstUser;
            SecondUser = secondUser;
        }

        public Guid Id { get; set; }

        public UserContext FirstUser { get; set; }

        public UserContext SecondUser { get; set; }
    }
}
