using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Network.Users
{
    public class MemoryGetUserByIdQuery : IGetUserByIdQuery
    {
        private readonly ConcurrentDictionary<Guid, UserContext> userStorage;

        public MemoryGetUserByIdQuery(ConcurrentDictionary<Guid, UserContext> userStorage)
        {
            this.userStorage = userStorage;
        }

        public Task<UserContext> Get(Guid userId)
        {
            userStorage.TryGetValue(userId, out var userContext);

            return Task.FromResult(userContext);
        }
    }
}
