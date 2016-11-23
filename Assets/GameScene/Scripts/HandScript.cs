using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class HandScript : ObservableScript
    {
        [SerializeField]
        [Tooltip("Префаб карты")]
        public GameObject cardPrefab;

        [SerializeField]
        [Tooltip("Объект колоды карт")]
        public GameObject deckObject;

        [SerializeField]
        [Tooltip("Объект истории карт")]
        public GameObject historyObject;

        [SerializeField]
        [Tooltip("Коллекция объектов, определяющих положение, вращение и масштаб карт")]
        public GameObject[] cardTemplates;

        private CardFactory cardFactory;

        public void Initialize(Hand hand, CardFactory cardFactory)
        {
            this.cardFactory = cardFactory;

            Initialize(
                hand.Observable(h => h.Cards, OnReplacedCard, OnInitializeCard));
        }

        private void OnInitializeCard(Card card, int index)
        {
            var cardTemplate = cardTemplates[index % cardTemplates.Length];
            var cardObject = cardFactory.CreateCard(cardPrefab, transform, card, index);
            cardObject.transform.CopyFrom(cardTemplate.transform);
        }

        private void OnReplacedCard(Card oldCard, Card newCard, int index)
        {
            var oldCardObject = transform.Find("Card" + index).gameObject;
            var oldCardDragDropScript = oldCardObject.GetComponent<CardDragDropScript>();
            var historyScript = historyObject.GetComponent<HistoryScript>();
            var playedReference = historyScript.Push(oldCard, oldCardDragDropScript.ResolveLatestPosition());
            Destroy(oldCardObject);

            var cardTemplate = cardTemplates[index % cardTemplates.Length];
            var cardObject = cardFactory.CreateCard(cardPrefab, transform, newCard, index);
            cardObject.transform.CopyFrom(cardTemplate.transform);
            cardObject.transform.position = deckObject.transform.position;
            cardObject.SetActive(false);

            StartCoroutine(TranslatePosition(cardObject, cardTemplate, playedReference));
        }

        private static IEnumerator TranslatePosition(GameObject cardObject, GameObject cardTemplate, Reference<bool> playedReference)
        {
            while (!playedReference.Value)
                yield return null;

            cardObject.SetActive(true);
            cardObject.AddComponent<CardTranslateScript>().Initialize(cardTemplate.transform.position);
        }
    }
}
