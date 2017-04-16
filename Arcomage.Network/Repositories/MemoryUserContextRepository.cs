using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Network.Repositories
{
    public class MemoryUserContextRepository : IUserContextRepository
    {
        private readonly ConcurrentDictionary<Guid, UserContext> userStorage =
            new ConcurrentDictionary<Guid, UserContext>();

        public MemoryUserContextRepository()
        {
#warning Hardcode users
            userStorage.AddOrUpdate(Guid.Parse("EB3AB862-E0D0-413B-B732-6BDD86B3A1A2"),
                new UserContext { Id = Guid.Parse("EB3AB862-E0D0-413B-B732-6BDD86B3A1A2") }, (_, u) => u);

            userStorage.AddOrUpdate(Guid.Parse("EB3AB862-E0D0-413B-B732-6BDD86B3A1A3"),
                new UserContext { Id = Guid.Parse("EB3AB862-E0D0-413B-B732-6BDD86B3A1A3") }, (_, u) => u);
        }

        public Task<UserContext> GetById(Guid id)
        {
            userStorage.TryGetValue(id, out var userContext);

            return Task.FromResult(userContext);
        }
    }
}
