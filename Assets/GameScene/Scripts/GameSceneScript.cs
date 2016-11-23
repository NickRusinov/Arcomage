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
    public class GameSceneScript : Script
    {
        [SerializeField]
        [Tooltip("Корневой компонент игры")]
        public GameScript GameScript;

        [SerializeField]
        [Tooltip("Компонент сообщения о победе")]
        public FinishedMenuScript FinishedScript;

        private DiContainer container;

        public override void Awake()
        {
            container = new DiContainer();
            container.Bind<Settings>().ToSelf().AsSingle(0);
            GameInstaller.Install(container);
            SceneInstaller.Install(container);
        }

        public override void Start()
        {
            GameScript.Initialize(container.Resolve<Game>(), container.Resolve<GameLoop>(), (ClassicRule)container.Resolve<Rule>(), container.Resolve<CardFactory>());
            FinishedScript.Initialize(container.Resolve<Game>());
        }
    }
}
