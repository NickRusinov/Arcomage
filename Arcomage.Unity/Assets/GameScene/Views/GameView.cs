using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain.Players;
using Arcomage.Unity.GameScene.Commands;
using Arcomage.Unity.GameScene.Scripts;
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
        public void Initialize(GameViewModel gameViewModel)
        {
            Bind(GameSceneScript.Dispatcher, d => d.Execute(new UpdateCommand()));

            Bind(gameViewModel.FinishedMenu, f => f.Identifier)
                .OnChangedAndInit(id => !string.IsNullOrEmpty(id), id => FinishedEvent.Invoke());

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