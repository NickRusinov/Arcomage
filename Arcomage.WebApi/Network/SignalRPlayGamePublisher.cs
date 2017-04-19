using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain;
using Arcomage.Network;
using Arcomage.Network.Jobs;
using Arcomage.WebApi.Hubs;
using Arcomage.WebApi.Models.Game;
using AutoMapper;
using Microsoft.AspNet.SignalR;

namespace Arcomage.WebApi.Network
{
    public class SignalRPlayGamePublisher : DecoratorPlayGamePublisher
    {
        private readonly IHubContext<IPlayGameClient> playGameHubContext;

        public SignalRPlayGamePublisher(IPlayGamePublisher playGamePublisher, IHubContext<IPlayGameClient> playGameHubContext) 
            : base(playGamePublisher)
        {
            this.playGameHubContext = playGameHubContext;
        }

        public override async Task OnAfterPlay(GameContext gameContext, Game game)
        {
            var model = Mapper.Map<GameModel>((gameContext, game));

            var firstUser = gameContext.FirstUser.Id.ToString();
            var secondUser = gameContext.SecondUser.Id.ToString();
            var users = new[] { firstUser, secondUser };

            playGameHubContext.Clients.Users(users).Update(model);

            await base.OnAfterPlay(gameContext, game);
        }
    }
}