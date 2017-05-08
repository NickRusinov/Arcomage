using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Arcomage.Network.Requests
{
    public class GetOrAddUserRequest : IRequest<UserContext>
    {
        public GetOrAddUserRequest(string name, UserKind kind)
        {
            Name = name;
            Kind = kind;
        }

        public string Name { get; set; }

        public UserKind Kind { get; set; }
    }
}
