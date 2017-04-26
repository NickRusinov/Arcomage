using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Arcomage.Network.Requests
{
    public class DiscardCardGameRequest : IRequest
    {
        public DiscardCardGameRequest(GameContext gameContext, UserContext userContext, int index)
        {
            GameContext = gameContext;
            UserContext = userContext;
            Index = index;
        }

        public GameContext GameContext { get; set; }

        public UserContext UserContext { get; set; }

        public int Index { get; set; }
    }
}
