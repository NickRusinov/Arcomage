using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Unity.GameScene.ViewModels;
using Arcomage.Unity.Shared.Scripts;
using Arcomage.WebApi.Client.Hubs;

namespace Arcomage.Unity.GameScene.Commands
{
    public class NetworkPlayCardCommand : Command<CardViewModel>
    {
        private readonly PlayGameHubClient playGameHubClient;

        public NetworkPlayCardCommand(PlayGameHubClient playGameHubClient)
        {
            this.playGameHubClient = playGameHubClient;
        }

        public override Task Execute(CardViewModel state)
        {
            return playGameHubClient.Start()
                .ContinueWith(t => playGameHubClient.PlayCard(state.Index), 
                    TaskContinuationOptions.ExecuteSynchronously);
        }
    }
}
