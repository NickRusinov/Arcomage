using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.SettingsScene.Scripts;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;

namespace Arcomage.Unity.SettingsScene.Views
{
    public class DeckListView : View
    {
        [Tooltip("Фабрика для создания объектов выбора колод карт")]
        public DeckFactory DeckFactory;

        public void Initialize()
        {
            DeckFactory.CreateDeck(transform, new DeckInfo("Classic"));
            DeckFactory.CreateDeck(transform, new DeckInfo("Infinity"));
        }
    }
}
