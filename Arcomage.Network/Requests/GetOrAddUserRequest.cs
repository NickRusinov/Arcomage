using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Arcomage.Network.Requests
{
    public class GetOrAddUserRequest : IRequest<User>
    {
        public GetOrAddUserRequest(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
