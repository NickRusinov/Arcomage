using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain;
using Arcomage.Domain.Players;
using Arcomage.Domain.Rules;
using Arcomage.Domain.Services;
using Arcomage.Unity.GameScene.Factories;
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

        [Tooltip("Корневой компонент игры")]
        public GameView GameScript;

        [Tooltip("Фабрика для создания карт")]
        public CardFactory CardFactory;

        [Tooltip("Фабрика для создания карт в истории")]
        public HistoryCardFactory HistoryCardFactory;

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
            var game = container.Resolve<Game>();
            var gameLoop = container.Resolve<GameLoop>();
            var humanPlayer = (HumanPlayer)container.Resolve<Player>("FirstPlayer");
            var playCardCriteria = container.Resolve<IPlayCardCriteria>();
            var discardCardCriteria = container.Resolve<IDiscardCardCriteria>();

            var gameViewModel = container.Resolve<GameViewModel>();
            UpdateViewModelsAction.Update(gameViewModel, game, (ClassicRuleInfo)Settings.Instance.Rule);
            
            GameScript.Initialize(gameViewModel, game, gameLoop);
            CardFactory.Initialize(game, humanPlayer, playCardCriteria, discardCardCriteria);
            FinishedScript.Initialize(gameViewModel.FinishedMenu);
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                FinishedScript.OnBackClickHandler();
        }
    }
}
