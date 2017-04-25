using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Network.Queries
{
    public class MemoryGetConnectingUsersQuery : IGetConnectingUsersQuery
    {
        private readonly ConcurrentDictionary<Guid, UserContext> userStorage;

        public MemoryGetConnectingUsersQuery(ConcurrentDictionary<Guid, UserContext> userStorage)
        {
            this.userStorage = userStorage;
        }

        public Task<IEnumerable<UserContext>> Handle()
        {
            var userContextList = userStorage.Values
                .Where(uc => uc.State.HasFlag(UserState.Connecting)).ToList();

            return Task.FromResult<IEnumerable<UserContext>>(userContextList);
        }
    }
}
