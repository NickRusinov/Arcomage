using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain;
using Arcomage.Domain.Players;
using Arcomage.Unity.GameScene.ViewModels;
using Arcomage.Unity.Shared.Scripts;
using SmartLocalization;
using UnityEngine;
using UnityEngine.Events;

namespace Arcomage.Unity.GameScene.Views
{
    /// <summary>
    /// Представление компонента игры
    /// </summary>
    public class GameView : View
    {
        [Tooltip("Событие: Игра завершена")]
        public UnityEvent FinishedEvent;

        [Tooltip("Компонент ресурсов первого игрока")]
        public ResourcesView LeftResources;

        [Tooltip("Компонент ресурсов второго игрока")]
        public ResourcesView RightResources;

        [Tooltip("Компонент строений первого игрока")]
        public BuildingsView LeftBuildings;

        [Tooltip("Компонент строений второго игрока")]
        public BuildingsView RightBuildings;

        [Tooltip("Компонент истории текущего хода")]
        public HistoryView History;

        [Tooltip("Компонент карт первого игрока")]
        public HandView Hand;

        [Tooltip("Текст для вывода информации для сброса карты")]
        public TextMesh DiscardOnlyText;

        /// <summary>
        /// Инициализация компонента
        /// </summary>
        /// <param name="gameViewModel">Модель представления контекста игры</param>
        /// <param name="game">Контекст игры</param>
        /// <param name="gameLoop">Игровой цикл</param>
        public void Initialize(GameViewModel gameViewModel, Game game, GameLoop gameLoop)
        {
            Bind(gameLoop, gl => gl.Update(game))
                .OnChangedAndInit(gr => gr, gr => FinishedEvent.Invoke());

            Bind(gameViewModel, g => g.DiscardOnly)
                .OnChangedAndInit(@do => DiscardOnlyText.gameObject.SetActive(@do > 0 && gameViewModel.PlayerKind == PlayerKind.First))
                .OnChangedAndInit(@do => DiscardOnlyText.text = LanguageManager.Instance.GetTextValue("GameDiscardText"));

            LeftResources.Initialize(gameViewModel.LeftResources);
            RightResources.Initialize(gameViewModel.RightResources);

            LeftBuildings.Initialize(gameViewModel.LeftBuildings);
            RightBuildings.Initialize(gameViewModel.RightBuildings);

            History.Initialize(gameViewModel.History);
            Hand.Initialize(gameViewModel.Hand);
        }
    }
}