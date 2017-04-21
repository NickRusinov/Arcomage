using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.WebApi.Client.Models.Game;

namespace Arcomage.WebApi.Client.Controllers
{
    public class GetGameControllerClient : ApplicationControllerClient
    {
        public GetGameControllerClient(IHttpClientFactory httpClientFactory) 
            : base(httpClientFactory)
        {

        }

        public Task<GameModel> GetGame(Guid id)
        {
            return Get<GameModel>($"api/game/{id}");
        }
    }
}
