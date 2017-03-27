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
    public class GameSceneScript : SceneScript
    {
        /// <summary>
        /// Игра поставлена на паузу
        /// </summary>
        public static bool Pause;

        /// <summary>
        /// Диспетчер выполнения команд
        /// </summary>
        public static CommandDispatcher Dispatcher;

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
            container.Bind<Settings>().ToSelf().AsSingle(0);
            GameInstaller.Install(container);
        }

        public void Start()
        {
            Dispatcher = container.Resolve<CommandDispatcher>();
            var gameViewModel = container.Resolve<GameViewModel>();
            var gameExecutor = container.Resolve<SingleGameExecutor>();

            StartCoroutine(gameExecutor.Execute());
            GameScript.Initialize(gameViewModel);
            FinishedScript.Initialize(gameViewModel.FinishedMenu);
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                FinishedScript.OnBackClickHandler();
        }
    }
}
