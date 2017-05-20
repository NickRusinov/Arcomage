using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Arcomage.Network.Requests
{
    public class PlayCardGameRequest : IRequest
    {
        public PlayCardGameRequest(GameContext gameContext, User user, int index)
        {
            GameContext = gameContext;
            User = user;
            Index = index;
        }

        public GameContext GameContext { get; set; }

        public User User { get; set; }

        public int Index { get; set; }
    }
}
