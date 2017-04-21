using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.WebApi.Client.Controllers
{
    public class ConnectGameControllerClient : ApplicationControllerClient
    {
        public ConnectGameControllerClient(IHttpClientFactory httpClientFactory) 
            : base(httpClientFactory)
        {

        }

        public Task<Guid?> GetConnecting()
        {
            return Get<Guid?>("api/game/connecting");
        }

        public Task Connect()
        {
            return Post("api/game/connect");
        }

        public Task Disconnect()
        {
            return Post("api/game/disconnect");
        }
    }
}
