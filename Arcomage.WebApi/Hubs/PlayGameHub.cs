using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Network.Services;
using Microsoft.AspNet.SignalR;

namespace Arcomage.WebApi.Hubs
{
    [Authorize]
    public class PlayGameHub : ApplicationHub<IPlayGameClient>
    {
        private readonly IPlayGameService playGameService;

        public PlayGameHub(IPlayGameService playGameService)
        {
            this.playGameService = playGameService;
        }

        public async Task PlayCard(int cardIndex)
        {
            await playGameService.PlayCard(Identity.Id, cardIndex);
        }

        public async Task DiscardCard(int cardIndex)
        {
            await playGameService.DiscardCard(Identity.Id, cardIndex);
        }
    }
}