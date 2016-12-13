using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Rules;
using Arcomage.Unity.GameScene.Views;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;
using Zenject;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class GameSceneScript : MonoBehaviour
    {
        public static bool Pause;

        [Tooltip("Корневой компонент игры")]
        public GameView GameScript;

        [Tooltip("Фабрика для создания карт")]
        public CardFactory CardFactory;

        [Tooltip("Фабрика для создания карт в истории")]
        public HistoryCardFactory HistoryCardFactory;

        [Tooltip("Компонент сообщения о победе")]
        public FinishedMenuView FinishedScript;

        private DiContainer container;

        public void Awake()
        {
            Pause = false;
            container = new DiContainer();
            container.Bind<Settings>().ToSelf().AsSingle(0);
            GameInstaller.Install(container);
            SceneInstaller.Install(container);
        }

        public void Start()
        {
            GameScript.Initialize(container.Resolve<Game>(), container.Resolve<GameLoop>(), (ClassicRule)container.Resolve<Rule>());
            CardFactory.Initialize(container.Resolve<Command>("PlayCardCommand"), container.Resolve<Command>("DiscardCardCommand"));
            FinishedScript.Initialize(container.Resolve<Game>());
        }
    }
}
