using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Arcomage.Network.Services;

namespace Arcomage.WebApi.Controllers
{
    [Authorize]
    public class ConnectGameApiController : ApplicationApiController
    {
        private readonly IConnectGameService connectGameService;

        public ConnectGameApiController(IConnectGameService connectGameService)
        {
            this.connectGameService = connectGameService;
        }

        [HttpPost, Route("~/api/game/connect")]
        public async Task<Guid> Connect()
        {
            var gameContext = await connectGameService.ConnectGame(Identity.Id);

            return gameContext.Id;
        }
    }
}