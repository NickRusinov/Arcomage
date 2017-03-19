using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.WebApi.Client.Models.Game;

namespace Arcomage.WebApi.Client.Controllers
{
    public class GameControllerClient : ControllerClient
    {
        public GameControllerClient(IHttpClientFactory httpClientFactory) 
            : base(httpClientFactory)
        {

        }

        public Task<GameModel> GetGame(Guid gameId)
        {
            return Get<GameModel>($"api/game/{gameId}");
        }
    }
}
