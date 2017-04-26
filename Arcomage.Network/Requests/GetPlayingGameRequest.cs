using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Arcomage.Network.Requests
{
    public class GetPlayingGameRequest : IRequest<GameContext>
    {
        public GetPlayingGameRequest(UserContext userContext)
        {
            UserContext = userContext;
        }

        public UserContext UserContext { get; set; }
    }
}
