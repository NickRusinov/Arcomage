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
    public class GameScript : View
    {
        [Tooltip("Событие: Игра завершена")]
        public UnityEvent FinishedEvent;

        [Tooltip("Компонент ресурсов первого игрока")]
        public ResourcesScript LeftResources;

        [Tooltip("Компонент ресурсов второго игрока")]
        public ResourcesScript RightResources;

        [Tooltip("Компонент строений первого игрока")]
        public BuildingsScript LeftBuildings;

        [Tooltip("Компонент строений второго игрока")]
        public BuildingsScript RightBuildings;

        [Tooltip("Компонент истории текущего хода")]
        public HistoryScript History;

        [Tooltip("Компонент карт первого игрока")]
        public HandScript Hand;
        
        public void Initialize(Game game, GameLoop gameLoop, ClassicRule rule)
        {
            Bind(gameLoop, gl => gl.Update())
                .OnChangedAndInit(gr => gr, gr => FinishedEvent.Invoke());

            LeftResources.Initialize(game.FirstPlayer.Resources);
            RightResources.Initialize(game.SecondPlayer.Resources);

            LeftBuildings.Initialize(game.FirstPlayer.Buildings, rule);
            RightBuildings.Initialize(game.SecondPlayer.Buildings, rule);

            History.Initialize(game.History);
            Hand.Initialize(game.FirstPlayer.Hand);
        }
    }
}