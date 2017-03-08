using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.WebApi.Client.Hubs
{
    public class NetworkGameClient : HubClient
    {
        public NetworkGameClient(ISignalRClient signalRClient)
            : base(signalRClient, "NetworkGameHub")
        {
            
        }
    }
}
