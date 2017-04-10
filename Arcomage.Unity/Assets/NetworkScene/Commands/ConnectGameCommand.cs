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
        private readonly UnityDispatcher unityDispatcher;

        private readonly ConnectGameHubClient connectGameHubClient;

        public ConnectGameCommand(UnityDispatcher unityDispatcher, ConnectGameHubClient connectGameHubClient)
        {
            this.unityDispatcher = unityDispatcher;
            this.connectGameHubClient = connectGameHubClient;
        }
        
        public override Task Execute(object state)
        {
            connectGameHubClient.OnConnected += unityDispatcher.Invoke<Guid>(OnConnected);

            return connectGameHubClient.Start()
                .ContinueWith(t => connectGameHubClient.Connect());
        }

        private void OnConnected(Guid gameId)
        {
            SceneManager.LoadSceneAsync("GameScene");
        }
    }
}
