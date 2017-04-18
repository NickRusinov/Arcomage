using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Unity.Shared.Scripts;
using Arcomage.WebApi.Client.Hubs;

namespace Arcomage.Unity.NetworkScene.Commands
{
    public class ConnectGameCommand : Command<object>
    {
        private readonly UnityDispatcher dispatcher;

        private readonly UnitySceneManager sceneManager;

        private readonly ConnectGameHubClient connectGameHubClient;

        public ConnectGameCommand(UnityDispatcher dispatcher, UnitySceneManager sceneManager, ConnectGameHubClient connectGameHubClient)
        {
            this.dispatcher = dispatcher;
            this.sceneManager = sceneManager;
            this.connectGameHubClient = connectGameHubClient;
        }
        
        public override Task Execute(object state)
        {
            connectGameHubClient.OnConnected += dispatcher.Invoke<Guid>(OnConnected);

            return connectGameHubClient.Connect();
        }

        private void OnConnected(Guid gameId)
        {
            sceneManager.LoadGameScene();
        }
    }
}
