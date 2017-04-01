using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Unity.GameScene.ViewModels;
using Arcomage.Unity.GameScene.Views;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;
using Zenject;

namespace Arcomage.Unity.GameScene.Scripts
{
    /// <summary>
    /// Корневой скрипт сцены
    /// </summary>
    public class GameSceneScript : Scene
    {
        /// <summary>
        /// Игра поставлена на паузу
        /// </summary>
        public static bool Pause;

        [Tooltip("Корневой компонент игры")]
        public GameView GameScript;

        [Tooltip("Компонент сообщения о победе")]
        public FinishedMenuView FinishedScript;

        /// <summary>
        /// Контейнер внедрения зависимостей для текущий сцены
        /// </summary>
        private DiContainer container;

        public override void Awake()
        {
            base.Awake();

            Pause = false;
            container = new DiContainer();
            container.Bind<SingleSettings>().FromMethod(c => Settings.Instance.Single);
            container.Bind<NetworkSettings>().FromMethod(c => Settings.Instance.Network);
            SingleGameSceneInstaller.Install(container);
            NetworkGameSceneInstaller.Install(container);
        }

        public void Start()
        {
            var gameViewModel = container.Resolve<GameViewModel>();
            var gameExecutor = container.Resolve<SingleGameExecutor>();

            StartCoroutine(gameExecutor.Execute());
            GameScript.ViewModel = gameViewModel;
            FinishedScript.ViewModel = gameViewModel.FinishedMenu;
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                FinishedScript.OnBackClickHandler();
        }
    }
}
