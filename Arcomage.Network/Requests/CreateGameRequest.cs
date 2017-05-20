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
        public CreateGameRequest(User firstUser, User secondUser)
        {
            FirstUser = firstUser;
            SecondUser = secondUser;
        }

        public User FirstUser { get; set; }

        public User SecondUser { get; set; }
    }
}
