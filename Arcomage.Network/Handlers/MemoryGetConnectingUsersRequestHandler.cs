using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Network.Requests;
using MediatR;

namespace Arcomage.Network.Handlers
{
    public class MemoryGetConnectingUsersRequestHandler : IRequestHandler<GetConnectingUsersRequest, IEnumerable<UserContext>>
    {
        private readonly ConcurrentDictionary<Guid, UserContext> userStorage;

        public MemoryGetConnectingUsersRequestHandler(ConcurrentDictionary<Guid, UserContext> userStorage)
        {
            this.userStorage = userStorage;
        }

        public IEnumerable<UserContext> Handle(GetConnectingUsersRequest message)
        {
            return userStorage.Values
                .Where(uc => uc.State.HasFlag(UserState.Connecting)).ToList();
        }
    }
}
