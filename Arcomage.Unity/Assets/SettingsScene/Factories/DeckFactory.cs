using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Decks;
using Arcomage.Unity.SettingsScene.Views;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Arcomage.Unity.SettingsScene.Factories
{
    public class DeckFactory : MonoBehaviour
    {
        [Tooltip("Префаб колоды")]
        public GameObject Prefab;

        [Tooltip("Аниматор, анимирующие появление и скрытие списка выбора колоды")]
        public Animator Animator;

        public GameObject CreateDeck(Transform transform, SingleSettings singleSettings, DeckInfo deckInfo)
        {
            var deckObject = (GameObject)Instantiate(Prefab, transform);
            deckObject.transform.localScale = Vector3.one;
            deckObject.name = "Deck" + deckInfo.Identifier;

            var deckView = deckObject.GetComponent<DeckView>();
            deckView.Initialize(deckInfo);

            var deckButton = deckObject.GetComponent<Button>();
            deckButton.onClick.AddListener(() => singleSettings.Deck = deckInfo);
            deckButton.onClick.AddListener(() => Animator.Play("HideDeckAnimation"));

            return deckObject;
        }
    }
}
