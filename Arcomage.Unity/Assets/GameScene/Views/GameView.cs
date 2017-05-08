using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Unity.Framework;
using Arcomage.Unity.Framework.Bindings;
using Arcomage.Unity.GameScene.ViewModels;
using UnityEngine;
using UnityEngine.Events;

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
        public GameObject DiscardOnlyText;

        [Tooltip("Текст для вывода информации о ходе игрока")]
        public GameObject YouPlayText;

        protected override void OnViewModel(GameViewModel viewModel)
        {
            Bind(viewModel.FinishedMenu, f => f.Identifier)
                .OnChangedAndInit(id => !string.IsNullOrEmpty(id), id => FinishedEvent.Invoke());

            Bind(viewModel, g => g.DiscardOnly)
                .OnChangedAndInit(@do => DiscardOnlyText.SetActive(@do > 0 && viewModel.CurrentPlayerKind == viewModel.UserPlayerKind))
                .OnChangedAndInit(@do => YouPlayText.SetActive(@do == 0 && viewModel.CurrentPlayerKind == viewModel.UserPlayerKind));

            Bind(viewModel, g => g.CurrentPlayerKind)
                .OnChangedAndInit(pk => DiscardOnlyText.SetActive(viewModel.DiscardOnly > 0 && pk == viewModel.UserPlayerKind))
                .OnChangedAndInit(pk => YouPlayText.SetActive(viewModel.DiscardOnly == 0 && pk == viewModel.UserPlayerKind));

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