using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.SettingsScene.ViewModels;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;

namespace Arcomage.Unity.SettingsScene.Views
{
    public class DeckView : View<DeckViewModel>
    {
        [Tooltip("Текст для вывода названия колоды")]
        public LocalizationScript NameText;

        [Tooltip("Текст для вывода описания колоды")]
        public LocalizationScript DescriptionText;

        protected override void OnViewModel(DeckViewModel viewModel)
        {
            NameText.identifier = "Deck" + viewModel.DeckInfo.Identifier + "Name";
            DescriptionText.identifier = "Deck" + viewModel.DeckInfo.Identifier + "Description";
            DescriptionText.arguments = new string[0];
        }
    }
}
