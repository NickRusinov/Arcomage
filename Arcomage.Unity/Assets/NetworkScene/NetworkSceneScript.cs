using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.NetworkScene.Views;
using Arcomage.Unity.Shared.Scripts;
using Arcomage.WebApi.Client;
using Arcomage.WebApi.Client.Controllers;
using Arcomage.WebApi.Client.Hubs;
using UnityEngine;
using Zenject;

namespace Arcomage.Unity.NetworkScene
{
    /// <summary>
    /// Корневой скрипт сцены настроек сетевой игры
    /// </summary>
    [RequireComponent(typeof(UnityHttpClient))]
    [RequireComponent(typeof(UnitySignalRClient))]
    public class NetworkSceneScript : SceneScript
    {
        [Tooltip("Панель, информирующая о соединении с игровым веб-сервером")]
        public ConnectPanelView ConnectPanel;

        [Tooltip("Панель, информирующая о подготовке к началу игры и поиске соперника")]
        public PreparePanelView PreparePanel;

        /// <summary>
        /// Контейнер внедрения зависимостей для текущий сцены
        /// </summary>
        private DiContainer container;

        public override void Awake()
        {
            base.Awake();

            container = new DiContainer();
            container.Bind<IHttpClient>().FromInstance(GetComponent<UnityHttpClient>());
            container.Bind<ISignalRClient>().FromInstance(GetComponent<UnitySignalRClient>());
            NetworkSceneInstaller.Install(container);
        }

        public void Start()
        {
            var aboutClient = container.Resolve<AboutClient>();
            var networkGameClient = container.Resolve<NetworkGameClient>();

            ConnectPanel.Initialize(aboutClient);
            PreparePanel.Initialize(networkGameClient);
        }

        public void Update()
        {
            //if (Input.GetKeyDown(KeyCode.Escape))
            //    OnBackClickHandler();
        }
    }
}
