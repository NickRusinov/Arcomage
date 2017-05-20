using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Network.Repositories
{
    public class MemoryUserRepository : IRepository<User>
    {
        private readonly ConcurrentDictionary<Guid, User> userStorage;

        public MemoryUserRepository(ConcurrentDictionary<Guid, User> userStorage)
        {
            this.userStorage = userStorage;
        }

        public Task<User> GetById(Guid id)
        {
            userStorage.TryGetValue(id, out var user);

            return Task.FromResult(user);
        }

        public Task<bool> DeleteById(Guid id)
        {
            userStorage.TryRemove(id, out _);

            return Task.FromResult(true);
        }

        public Task<bool> Add(User user)
        {
            userStorage.AddOrUpdate(user.Id, user, (_, g) => g);

            return Task.FromResult(true);
        }

        public Task<bool> Save(User user)
        {
            userStorage.AddOrUpdate(user.Id, user, (_, g) => user);

            return Task.FromResult(true);
        }

        public Task<bool> Update(User user, Action<User> update)
        {
            userStorage.AddOrUpdate(user.Id,
                id =>
                {
                    update(user);

                    return user;
                },
                (id, u) =>
                {
                    update(user);
                    update(u);

                    return u;
                });

            return Task.FromResult(true);
        }
    }
}
