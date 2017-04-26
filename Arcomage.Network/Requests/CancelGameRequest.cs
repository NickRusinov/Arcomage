using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Arcomage.Network.Requests
{
    public class CancelGameRequest : IRequest
    {
        public CancelGameRequest(GameContext gameContext)
        {
            GameContext = gameContext;
        }

        public GameContext GameContext { get; set; }
    }
}
