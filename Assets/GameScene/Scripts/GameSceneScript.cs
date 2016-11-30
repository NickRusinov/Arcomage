using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Rules;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;
using Zenject;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class GameSceneScript : MonoBehaviour
    {
        [Tooltip("Корневой компонент игры")]
        public GameScript GameScript;

        [Tooltip("Фабрика для создания карт")]
        public CardFactory CardFactory;

        [Tooltip("Компонент сообщения о победе")]
        public FinishedMenuScript FinishedScript;

        private DiContainer container;

        public void Awake()
        {
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
