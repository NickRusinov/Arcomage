using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Rules;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;
using UnityEngine.Events;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class GameScript : ObservableScript
    {
        [SerializeField]
        [Tooltip("Событие: Игра завершена")]
        public UnityEvent FinishedEvent;

        private GameLoop gameLoop;

        public void Initialize(Game game, GameLoop gameLoop, ClassicRule rule, CardFactory cardFactory)
        {
            this.gameLoop = gameLoop;

            this.ResolveScript<ResourcesScript>("ResourcesLeft").Initialize(game.FirstPlayer.Resources);
            this.ResolveScript<ResourcesScript>("ResourcesRight").Initialize(game.SecondPlayer.Resources);

            this.ResolveScript<BuildingsScript>("BuildingsLeft").Initialize(game.FirstPlayer.Buildings, rule);
            this.ResolveScript<BuildingsScript>("BuildingsRight").Initialize(game.SecondPlayer.Buildings, rule);

            this.ResolveScript<HistoryScript>("History").Initialize(game.History, cardFactory);
            this.ResolveScript<HandScript>("Hand").Initialize(game.FirstPlayer.Hand, cardFactory);
        }

        public override void Update()
        {
            if (gameLoop.Update())
                FinishedEvent.Invoke();

            base.Update();
        }
    }
}