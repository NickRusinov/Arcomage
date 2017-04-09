using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.WebApi.Client.Controllers
{
    public class PlayGameControllerClient : ApplicationControllerClient
    {
        public PlayGameControllerClient(IHttpClientFactory httpClientFactory) 
            : base(httpClientFactory)
        {

        }

        public Task PlayCard(int cardIndex)
        {
            return Post("api/game/play", new Dictionary<string, string>
            {
                { "cardIndex", cardIndex.ToString() }
            });
        }

        public Task DiscardCard(int cardIndex)
        {
            return Post("api/game/discard", new Dictionary<string, string>
            {
                { "cardIndex", cardIndex.ToString() }
            });
        }
    }
}
