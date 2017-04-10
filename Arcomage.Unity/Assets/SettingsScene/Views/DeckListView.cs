using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Decks;
using Arcomage.Unity.SettingsScene.Factories;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;
using Random = System.Random;

namespace Arcomage.Unity.SettingsScene.Views
{
    public class DeckListView : View
    {
        [Tooltip("Фабрика для создания объектов выбора колод карт")]
        public DeckFactory DeckFactory;

        public void Initialize(SingleSettings singleSettings)
        {
            DeckFactory.CreateDeck(transform, singleSettings, new ClassicDeckInfo("Classic", new Random()));
            DeckFactory.CreateDeck(transform, singleSettings, new InfinityDeckInfo("Infinity", new Random()));
        }
    }
}
