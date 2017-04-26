using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Arcomage.Network.Requests
{
    public class CreateGameRequest : IRequest<GameContext>
    {
        public CreateGameRequest(UserContext firstUserContext, UserContext secondUserContext)
        {
            FirstUserContext = firstUserContext;
            SecondUserContext = secondUserContext;
        }

        public UserContext FirstUserContext { get; set; }

        public UserContext SecondUserContext { get; set; }
    }
}
