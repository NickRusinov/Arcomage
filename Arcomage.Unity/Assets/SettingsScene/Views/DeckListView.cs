using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.SettingsScene.Scripts;
using Arcomage.Unity.SettingsScene.ViewModels;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;

namespace Arcomage.Unity.SettingsScene.Views
{
    public class DeckListView : View<DeckListViewModel>
    {
        [Tooltip("Фабрика для создания объектов выбора колод карт")]
        public DeckFactory DeckFactory;

        protected override void OnViewModel(DeckListViewModel viewModel)
        {
            foreach (var deckViewModel in viewModel.DeckCollection)
                DeckFactory.CreateDeck(transform, deckViewModel);
        }
    }
}
