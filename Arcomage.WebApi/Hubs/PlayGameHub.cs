using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace Arcomage.WebApi.Hubs
{
    [Authorize]
    public class PlayGameHub : ApplicationHub<IPlayGameClient>
    {
        private readonly PlayGameService playGameService;

        public PlayGameHub(PlayGameService playGameService)
        {
            this.playGameService = playGameService;
        }

        public async Task DiscardCard(int cardIndex)
        {
            var playGameContext = await playGameService.ResolveGameContext(Identity.Id);
            if (playGameContext == null)
                return;

            var tryDiscardCard = await playGameService.DiscardCard(playGameContext.GameId, Identity.Id, cardIndex);
            if (!tryDiscardCard)
                return;

            var firstUser = playGameContext.FirstUser;
            if (firstUser != null)
                Clients.User(firstUser.UserId.ToString()).Update();

            var secondUser = playGameContext.SecondUser;
            if (secondUser != null)
                Clients.User(secondUser.UserId.ToString()).Update();
        }

        public async Task PlayCard(int cardIndex)
        {
            var playGameContext = await playGameService.ResolveGameContext(Identity.Id);
            if (playGameContext == null)
                return;

            var tryPlayCard = await playGameService.PlayCard(playGameContext.GameId, Identity.Id, cardIndex);
            if (!tryPlayCard)
                return;

            var firstUser = playGameContext.FirstUser;
            if (firstUser != null)
                Clients.User(firstUser.UserId.ToString()).Update();

            var secondUser = playGameContext.SecondUser;
            if (secondUser != null)
                Clients.User(secondUser.UserId.ToString()).Update();
        }
    }
}