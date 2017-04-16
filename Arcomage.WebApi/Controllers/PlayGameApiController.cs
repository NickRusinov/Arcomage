using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Arcomage.Network.Services;

namespace Arcomage.WebApi.Controllers
{
    [Authorize]
    public class PlayGameApiController : ApplicationApiController
    {
        private readonly IPlayGameService playGameService;

        public PlayGameApiController(IPlayGameService playGameService)
        {
            this.playGameService = playGameService;
        }

        [HttpPost, Route("~/api/game/play")]
        public async Task PlayCard(int cardIndex)
        {
            await playGameService.PlayCard(Identity.Id, cardIndex);
        }

        [HttpPost, Route("~/api/game/discard")]
        public async Task DiscardCard(int cardIndex)
        {
            await playGameService.DiscardCard(Identity.Id, cardIndex);
        }
    }
}