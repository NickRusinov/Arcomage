using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Arcomage.Network.Queries;
using Arcomage.Network.Services;

namespace Arcomage.WebApi.Controllers
{
    [Authorize]
    public class ConnectGameApiController : ApplicationApiController
    {
        private readonly IConnectGameService connectGameService;

        private readonly IDisconnectGameService disconnectGameService;

        private readonly GetConnectingGameQuery getConnectingGameQuery;

        public ConnectGameApiController(IConnectGameService connectGameService, IDisconnectGameService disconnectGameService, GetConnectingGameQuery getConnectingGameQuery)
        {
            this.connectGameService = connectGameService;
            this.disconnectGameService = disconnectGameService;
            this.getConnectingGameQuery = getConnectingGameQuery;
        }

        [HttpGet, Route("~/api/game/connecting")]
        public async Task<Guid?> GetConnecting()
        {
            var gameContext = await getConnectingGameQuery.Handle(Identity.Id);

            return gameContext?.Id;
        }

        [HttpPost, Route("~/api/game/connect")]
        public async Task<Guid?> Connect()
        {
            var gameContext = await connectGameService.ConnectGame(Identity.Id);

            return gameContext?.Id;
        }

        [HttpPost, Route("~/api/game/disconnect")]
        public async Task<Guid?> Disconnect()
        {
            var gameContext = await disconnectGameService.DisconnectGame(Identity.Id);

            return gameContext?.Id;
        }
    }
}