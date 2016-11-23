using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Unity.Shared.Scripts;
using ModestTree.Util;
using UnityEngine;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class HistoryScript : ObservableScript
    {
        [SerializeField]
        [Tooltip("Префаб карты")]
        public GameObject cardPrefab;

        [SerializeField]
        [Tooltip("Объект, определяющий начальную позицию анимании появления карты и конечную позиция анимации удаления карты")]
        public GameObject cardInitTemplate;

        [SerializeField]
        [Tooltip("Коллекция объектов, определяющих позиции, на которых будут расположены карты после их добавления в историю")]
        public GameObject[] cardTemplates;

        private CardFactory cardFactory;

        private ValuePair<Card, Vector3> playedCard;

        private Reference<bool> playedReference;

        private bool cleared;

        public void Initialize(History history, CardFactory cardFactory)
        {
            this.cardFactory = cardFactory;

            Initialize(
                history.Observable(h => h.Cards, OnAddedCard, OnClearedCard));
        }

        public Reference<bool> Push(Card card, Vector3 position)
        {
            playedCard = ValuePair.New(card, position);
            playedReference = new Reference<bool>();

            return playedReference;
        }

        private void OnAddedCard(Card card, int index)
        {
            if (cleared)
            {
                foreach (var cardTransform in transform.FindByTag("Card"))
                    cardTransform.gameObject.AddComponent<CardTranslateScript>().Initialize(cardInitTemplate.transform.position,
                        g => Destroy(g));
            }

            if (playedCard != null && playedCard.First == card)
            {
                var cardTemplate = cardTemplates[index % cardTemplates.Length];
                var cardObject = cardFactory.CreateCard(cardPrefab, transform, card, index);
                cardObject.transform.CopyFrom(cardTemplate.transform);
                cardObject.transform.position = playedCard.Second;

                cardObject.AddComponent<CardTranslateScript>().Initialize(cardTemplate.transform.position,
                    g => playedReference.Value = true);
            }
            else
            {
                var cardTemplate = cardTemplates[index % cardTemplates.Length];
                var cardObject = cardFactory.CreateCard(cardPrefab, transform, card, index);
                cardObject.transform.CopyFrom(cardTemplate.transform);
                cardObject.transform.position = cardInitTemplate.transform.position;

                cardObject.AddComponent<CardTranslateScript>().Initialize(cardTemplate.transform.position);
                playedReference.Value = true;
            }

            cleared = false;
            playedCard = null;
        }

        private void OnClearedCard()
        {
            cleared = true;
            playedCard = null;
        }
    }
}
