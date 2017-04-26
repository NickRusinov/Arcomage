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
    public class MemoryGetOrAddUserRequestHandler : IRequestHandler<GetOrAddUserRequest, UserContext>
    {
        private readonly ConcurrentDictionary<Guid, UserContext> userStorage;

        public MemoryGetOrAddUserRequestHandler(ConcurrentDictionary<Guid, UserContext> userStorage)
        {
            this.userStorage = userStorage;
        }

        public UserContext Handle(GetOrAddUserRequest message)
        {
            var userContext = userStorage.Values
                .Where(uc => string.Equals(uc.Name, message.Name, OrdinalIgnoreCase))
                .SingleOrDefault() ?? UserContext.New(message.Name);

            return userStorage.GetOrAdd(userContext.Id, userContext);
        }
    }
}
