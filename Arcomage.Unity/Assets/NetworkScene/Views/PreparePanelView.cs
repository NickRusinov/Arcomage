using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Arcomage.Unity.Shared.Scripts;
using Arcomage.WebApi.Client.Hubs;
using UnityEngine;

namespace Arcomage.Unity.NetworkScene.Views
{
    public class PreparePanelView : View
    {
        private NetworkGameHubClient networkGameHubClient;

        public void Initialize(NetworkGameHubClient networkGameHubClient)
        {
            this.networkGameHubClient = networkGameHubClient;
        }

        public void OnEnable()
        {
			networkGameHubClient.OnStartGame += id => Debug.Log(id);
            networkGameHubClient.Start().ContinueWith(t => networkGameHubClient.Connect());
        }

        public void OnDisable()
        {
            networkGameHubClient.Stop();
        }
    }
}
