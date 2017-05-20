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
        public GetPlayingGameRequest(User user)
        {
            User = user;
        }

        public User User { get; set; }
    }
}
