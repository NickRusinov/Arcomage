using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.WebApi.Hubs;
using Microsoft.AspNet.SignalR;

namespace Arcomage.WebApi
{
    public class NetworkGameService
    {
        private readonly ConcurrentDictionary<Guid, Task> readyUsers = new ConcurrentDictionary<Guid, Task>();

        private readonly IHubContext<INetworkGameClient> networkGameHubContext;

        public NetworkGameService(IHubContext<INetworkGameClient> networkGameHubContext)
        {
            this.networkGameHubContext = networkGameHubContext;
        }

        public void ConnectUser(Guid userId)
        {
            readyUsers.AddOrUpdate(userId, ExecuteSearch, (_, t) => t);
        }

        public void DisconnectUser(Guid userId)
        {
            readyUsers.Clear();
        }

        private async Task ExecuteSearch(Guid userId)
        {
            await Task.Delay(5000);

            // fake search game ...

            networkGameHubContext.Clients.User(userId.ToString()).StartGame(Guid.NewGuid());
        }
    }
}