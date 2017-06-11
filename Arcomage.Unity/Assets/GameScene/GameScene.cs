using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Unity.Framework;
using Arcomage.Unity.GameScene.Scripts;
using Arcomage.Unity.GameScene.ViewModels;
using Arcomage.Unity.GameScene.Views;
using Autofac;
using UnityEngine;

namespace Arcomage.Unity.GameScene
{
    /// <summary>
    /// Корневой скрипт сцены
    /// </summary>
    public class GameScene : Scene
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
            var gameViewModel = LifetimeScope.Resolve<GameViewModel>();
            var gameExecutor = LifetimeScope.Resolve<GameExecutor>();

            StartCoroutine(gameExecutor.Execute());
            GameScript.ViewModel = gameViewModel;
            FinishedScript.ViewModel = gameViewModel.FinishedMenu;
        }
    }
}
