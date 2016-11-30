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
    public class HandScript : View
    {
        [Tooltip("Фабрика создания карт")]
        public CardFactory CardFactory;

        [Tooltip("Компонент истории текущего хода")]
        public HistoryScript History;

        [Tooltip("Объект, определяющий начальную позицию анимации появления карты")]
        public GameObject CardInitTemplate;
        
        [Tooltip("Коллекция объектов, определяющих положение, вращение и масштаб карт")]
        public GameObject[] CardTemplates;

        public void Initialize(Hand hand)
        {
            Bind(hand, h => h.Cards)
                .OnInit(OnInitializeCard)
                .OnReplaced(OnReplacedCard);
        }

        private void OnInitializeCard(Card card, int index)
        {
            var cardTemplate = CardTemplates[index % CardTemplates.Length];
            var cardObject = CardFactory.CreateCard(transform, card, index);
            cardObject.transform.CopyFrom(cardTemplate.transform);
        }

        private void OnReplacedCard(Card oldCard, Card newCard, int index)
        {
            var oldCardObject = transform.Find("Card" + index).gameObject;
            var oldCardDragDropScript = oldCardObject.GetComponent<CardDragDropScript>();
            var playedReference = History.Push(oldCard, oldCardDragDropScript.ResolveLatestPosition());
            Destroy(oldCardObject);

            var cardTemplate = CardTemplates[index % CardTemplates.Length];
            var cardObject = CardFactory.CreateCard(transform, newCard, index);
            cardObject.transform.CopyFrom(cardTemplate.transform);
            cardObject.transform.position = CardInitTemplate.transform.position;
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
