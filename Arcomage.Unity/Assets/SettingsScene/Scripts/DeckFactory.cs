using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Unity.SettingsScene.ViewModels;
using Arcomage.Unity.SettingsScene.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Arcomage.Unity.SettingsScene.Scripts
{
    public class DeckFactory : MonoBehaviour
    {
        [Tooltip("Префаб колоды")]
        public GameObject Prefab;

        [Tooltip("Аниматор, анимирующие появление и скрытие списка выбора колоды")]
        public Animator Animator;

        public GameObject CreateDeck(Transform transform, DeckViewModel viewModel)
        {
            var deckObject = (GameObject)Instantiate(Prefab, transform);
            deckObject.transform.localScale = Vector3.one;
            deckObject.name = "Deck" + viewModel.DeckInfo.Identifier;

            var deckView = deckObject.GetComponent<DeckView>();
            deckView.ViewModel = viewModel;

            var deckButton = deckObject.GetComponent<Button>();
            deckButton.onClick.AddListener(() => viewModel.Settings.Deck = viewModel.DeckInfo);
            deckButton.onClick.AddListener(() => Animator.Play("HideDeckAnimation"));

            return deckObject;
        }
    }
}
