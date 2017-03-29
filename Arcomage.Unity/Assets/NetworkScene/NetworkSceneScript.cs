using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.NetworkScene.ViewModels;
using Arcomage.Unity.NetworkScene.Views;
using Arcomage.Unity.Shared.Scripts;
using Arcomage.WebApi.Client;
using UnityEngine;
using Zenject;

namespace Arcomage.Unity.NetworkScene
{
    /// <summary>
    /// Корневой скрипт сцены настроек сетевой игры
    /// </summary>
    [RequireComponent(typeof(UnityHttpClientFactory))]
    [RequireComponent(typeof(UnityHubConnectionFactory))]
    public class NetworkSceneScript : Scene
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
            container.Bind<IHttpClientFactory>().FromInstance(GetComponent<UnityHttpClientFactory>());
            container.Bind<IHubConnectionFactory>().FromInstance(GetComponent<UnityHubConnectionFactory>());
            NetworkSceneInstaller.Install(container);
        }

        public void Start()
        {
            var connectViewModel = container.Resolve<ConnectViewModel>();
            var prepareViewModel = container.Resolve<PrepareViewModel>();

            ConnectPanel.ViewModel = connectViewModel;
            PreparePanel.ViewModel = prepareViewModel;
        }

        public void Update()
        {
            //if (Input.GetKeyDown(KeyCode.Escape))
            //    OnBackClickHandler();
        }
    }
}
