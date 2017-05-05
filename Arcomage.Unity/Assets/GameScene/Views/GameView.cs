using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain.Players;
using Arcomage.Unity.GameScene.ViewModels;
using Arcomage.Unity.Shared.Scripts;
using SmartLocalization;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Arcomage.Unity.GameScene.Views
{
    /// <summary>
    /// Представление компонента игры
    /// </summary>
    public class GameView : View<GameViewModel>
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

        [Tooltip("Компонент таймер")]
        public TimerView Timer;

        [Tooltip("Текст для вывода информации для сброса карты")]
        public Text DiscardOnlyText;

        protected override void OnViewModel(GameViewModel viewModel)
        {
            Bind(viewModel.FinishedMenu, f => f.Identifier)
                .OnChangedAndInit(id => !string.IsNullOrEmpty(id), id => FinishedEvent.Invoke());

            Bind(viewModel, g => g.DiscardOnly)
                .OnChangedAndInit(@do => DiscardOnlyText.gameObject.SetActive(@do > 0 && viewModel.PlayerKind == PlayerKind.First))
                .OnChangedAndInit(@do => DiscardOnlyText.text = LanguageManager.Instance.GetTextValue("GameDiscardText"));

            LeftResources.ViewModel = viewModel.LeftResources;
            RightResources.ViewModel = viewModel.RightResources;

            LeftBuildings.ViewModel = viewModel.LeftBuildings;
            RightBuildings.ViewModel = viewModel.RightBuildings;

            History.ViewModel = viewModel.History;
            Hand.ViewModel = viewModel.Hand;

            Timer.ViewModel = viewModel.Timer;
        }
    }
}