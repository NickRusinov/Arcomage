using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Unity.Shared.Scripts;
using Arcomage.WebApi.Client.Hubs;
using UnityEngine.SceneManagement;

namespace Arcomage.Unity.NetworkScene.Commands
{
    public class ConnectGameCommand : Command<object>
    {
        private readonly NetworkGameHubClient networkGameHubClient;

        public ConnectGameCommand(NetworkGameHubClient networkGameHubClient)
        {
            this.networkGameHubClient = networkGameHubClient;
        }
        
        public override Task Execute(object state)
        {
            networkGameHubClient.OnStartGame += UnityDispatcher.Dispatch<Guid>(OnStartGame);

            return networkGameHubClient.Start()
                .ContinueWith(t => networkGameHubClient.Connect());
        }

        private void OnStartGame(Guid gameId)
        {
            SceneManager.LoadSceneAsync("GameScene");
        }
    }
}
