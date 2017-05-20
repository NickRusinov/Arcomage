using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Arcomage.Network.Requests
{
    public class GetConnectingUsersRequest : IRequest<IEnumerable<User>>
    {

    }
}
