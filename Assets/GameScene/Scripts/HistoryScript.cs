﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Unity.Shared.Scripts;
using ModestTree.Util;
using UnityEngine;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class HistoryScript : View
    {
        [Tooltip("Фабрика создания карт")]
        public CardFactory СardFactory;
        
        [Tooltip("Объект, определяющий начальную позицию анимании появления карты и конечную позиция анимации удаления карты")]
        public GameObject СardInitTemplate;
        
        [Tooltip("Коллекция объектов, определяющих позиции, на которых будут расположены карты после их добавления в историю")]
        public GameObject[] СardTemplates;

        private ValuePair<Card, Vector3> playedCard;

        private Reference<bool> playedReference;

        private bool cleared;

        public void Initialize(History history)
        {
            Bind(history, h => h.Cards)
                .OnAdded(OnAddedCard)
                .OnCleared(OnClearedCard);
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
                foreach (var cardScript in GetComponentsInChildren<CardScript>())
                {
                    var cardTranslateScript = cardScript.gameObject.AddComponent<CardTranslateScript>();
                    cardTranslateScript.Initialize(СardInitTemplate.transform.position);
                    cardTranslateScript.EndedEvent.AddListener(() => ((bool)cardScript).IfTrue(() => Destroy(cardScript.gameObject)));
                }
            }

            if (playedCard != null && playedCard.First == card)
            {
                var cardTemplate = СardTemplates[index % СardTemplates.Length];
                var cardObject = СardFactory.CreateCard(transform, card, index);
                cardObject.transform.CopyFrom(cardTemplate.transform);
                cardObject.transform.position = playedCard.Second;

                var cardTranslateScript = cardObject.AddComponent<CardTranslateScript>();
                cardTranslateScript.Initialize(cardTemplate.transform.position);
                cardTranslateScript.EndedEvent.AddListener(() => playedReference.Value = true);
            }
            else
            {
                var cardTemplate = СardTemplates[index % СardTemplates.Length];
                var cardObject = СardFactory.CreateCard(transform, card, index);
                cardObject.transform.CopyFrom(cardTemplate.transform);
                cardObject.transform.position = СardInitTemplate.transform.position;

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
