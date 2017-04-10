using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Unity.GameScene.ViewModels;
using Arcomage.Unity.GameScene.Views;
using Arcomage.Unity.Shared.Scripts;
using Autofac;
using UnityEngine;

namespace Arcomage.Unity.GameScene.Scripts
{
    /// <summary>
    /// Корневой скрипт сцены
    /// </summary>
    [RequireComponent(typeof(UnityBackHandler))]
    [RequireComponent(typeof(UnitySceneManager))]
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

        public override void Awake()
        {
            base.Awake();

            Pause = false;
        }

        public void Start()
        {
            var gameViewModel = lifetimeScope.Resolve<GameViewModel>();
            var gameExecutor = lifetimeScope.Resolve<SingleGameExecutor>();

            StartCoroutine(gameExecutor.Execute());
            GameScript.ViewModel = gameViewModel;
            FinishedScript.ViewModel = gameViewModel.FinishedMenu;
        }
    }
}
