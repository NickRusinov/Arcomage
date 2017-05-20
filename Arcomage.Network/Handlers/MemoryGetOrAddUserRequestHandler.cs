using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Network.Requests;
using MediatR;
using static System.StringComparison;

namespace Arcomage.Network.Handlers
{
    public class MemoryGetOrAddUserRequestHandler : IRequestHandler<GetOrAddUserRequest, User>
    {
        private readonly ConcurrentDictionary<Guid, User> userStorage;

        public MemoryGetOrAddUserRequestHandler(ConcurrentDictionary<Guid, User> userStorage)
        {
            this.userStorage = userStorage;
        }

        public User Handle(GetOrAddUserRequest message)
        {
            var user = userStorage.Values
                .Where(uc => string.Equals(uc.Name, message.Name, OrdinalIgnoreCase))
                .SingleOrDefault() ?? new User { Id = Guid.NewGuid(), Name = message.Name };

            return userStorage.GetOrAdd(user.Id, user);
        }
    }
}
