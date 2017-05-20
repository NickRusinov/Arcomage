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
    public class MemoryGetConnectingUsersRequestHandler : IRequestHandler<GetConnectingUsersRequest, IEnumerable<User>>
    {
        private readonly ConcurrentDictionary<Guid, User> userStorage;

        public MemoryGetConnectingUsersRequestHandler(ConcurrentDictionary<Guid, User> userStorage)
        {
            this.userStorage = userStorage;
        }

        public IEnumerable<User> Handle(GetConnectingUsersRequest message)
        {
            return userStorage.Values
                .Where(uc => uc.State.HasFlag(UserState.Connecting)).ToList();
        }
    }
}
