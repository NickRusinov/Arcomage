using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;

namespace Arcomage.Unity.SettingsScene.Views
{
    public class DeckView : View
    {
        [Tooltip("Текст для вывода названия колоды")]
        public LocalizationScript NameText;

        [Tooltip("Текст для вывода описания колоды")]
        public LocalizationScript DescriptionText;

        public void Initialize(DeckInfo deckInfo)
        {
            NameText.identifier = "Deck" + deckInfo.Identifier + "Name";
            DescriptionText.identifier = "Deck" + deckInfo.Identifier + "Description";
            DescriptionText.arguments = deckInfo.GetArguments();
        }
    }
}
