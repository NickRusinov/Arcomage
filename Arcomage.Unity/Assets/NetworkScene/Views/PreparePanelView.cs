using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Arcomage.Unity.Shared.Scripts;
using Arcomage.WebApi.Client.Hubs;
using Microsoft.AspNet.SignalR.Client;

namespace Arcomage.Unity.NetworkScene.Views
{
    public class PreparePanelView : View
    {
        private NetworkGameClient networkGameClient;

        public void Initialize(NetworkGameClient networkGameClient)
        {
            this.networkGameClient = networkGameClient;
        }

        public void OnEnable()
        {
			networkGameClient.HubProxy.On("StartGame", (Guid id) => {});
            networkGameClient.Start();
        }

        public void OnDisable()
        {
            networkGameClient.Stop();
        }
    }
}
