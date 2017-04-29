using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.NetworkScene.Views;
using Arcomage.Unity.Shared.Scripts;
using Autofac;
using UnityEngine;

namespace Arcomage.Unity.NetworkScene
{
    /// <summary>
    /// Корневой скрипт сцены настроек сетевой игры
    /// </summary>
    [RequireComponent(typeof(UnityBackHandler))]
    [RequireComponent(typeof(UnitySceneManager))]
    [RequireComponent(typeof(UnityHttpClientFactory))]
    [RequireComponent(typeof(UnityHubConnectionFactory))]
    public class NetworkScene : Scene
    {
        [Tooltip("Панель, информирующая о соединении с игровым веб-сервером")]
        public ConnectPanelView ConnectPanel;

        [Tooltip("Панель, информирующая о существовании уже запущенной сетевой игры")]
        public ConnectDialogPanelView ConnectDialogPanelView;

        [Tooltip("Панель, информирующая о подготовке к началу игры и поиске соперника")]
        public PreparePanelView PreparePanel;

        public override void Awake()
        {
            base.Awake();

            var settings = lifetimeScope.Resolve<Settings>();

            settings.UseNetwork();
        }
    }
}
