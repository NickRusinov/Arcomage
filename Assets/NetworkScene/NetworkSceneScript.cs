using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.NetworkScene.Views;
using Arcomage.Unity.Shared.Scripts;
using Arcomage.WebApi.Client;
using Arcomage.WebApi.Client.Controllers;
using UnityEngine;
using Zenject;

namespace Arcomage.Unity.NetworkScene
{
    /// <summary>
    /// Корневой скрипт сцены настроек сетевой игры
    /// </summary>
    [RequireComponent(typeof(UnityHttpClient))]
    public class NetworkSceneScript : SceneScript
    {
        [Tooltip("Панель, информирующая о соединении с игровым веб-сервером")]
        public ConnectPanelView ConnectPanel;

        /// <summary>
        /// Контейнер внедрения зависимостей для текущий сцены
        /// </summary>
        private DiContainer container;

        public override void Awake()
        {
            base.Awake();

            container = new DiContainer();
            container.Bind<IHttpClient>().FromInstance(GetComponent<UnityHttpClient>());
            NetworkSceneInstaller.Install(container);
        }

        public void Start()
        {
            var aboutClient = container.Resolve<AboutClient>();

            ConnectPanel.Initialize(aboutClient);
        }

        public void Update()
        {
            //if (Input.GetKeyDown(KeyCode.Escape))
            //    OnBackClickHandler();
        }
    }
}
