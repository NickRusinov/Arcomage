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
        public GameScript gameScript;

        [SerializeField]
        public GameLoopScript gameLoopScript;

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
            gameScript.Initialize(container.Resolve<Game>(), (ClassicRule)container.Resolve<Rule>(), container.Resolve<CardFactory>());
            gameLoopScript.Initialize(container.Resolve<GameLoop>());
        }
    }
}
