using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Arcomage.Domain.Hands;
using Arcomage.Unity.GameScene.Factories;
using Arcomage.Unity.GameScene.Scripts;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;

namespace Arcomage.Unity.GameScene.Views
{
    /// <summary>
    /// Представление компонента карт на руках игрока
    /// </summary>
    public class HandView : View
    {
        [Tooltip("Фабрика создания карт")]
        public CardFactory CardFactory;

        [Tooltip("Компонент истории текущего хода")]
        public HistoryView History;

        [Tooltip("Объект, определяющий начальную позицию анимации появления карты")]
        public GameObject CardInitTemplate;
        
        [Tooltip("Коллекция объектов, определяющих положение, вращение и масштаб карт")]
        public GameObject[] CardTemplates;

        /// <summary>
        /// Инициализация компонента
        /// </summary>
        /// <param name="hand">Карты в руке игрока</param>
        public void Initialize(Hand hand)
        {
            Bind(hand, h => h.Cards)
                .OnInit(OnInitializeCard)
                .OnReplaced(OnReplacedCard);
        }

        /// <summary>
        /// Инициализация карты в начале игры
        /// </summary>
        /// <param name="card">Карта</param>
        /// <param name="index">Номер карты в руке</param>
        private void OnInitializeCard(Card card, int index)
        {
            var cardTemplate = CardTemplates[index % CardTemplates.Length];
            var cardObject = CardFactory.CreateCard(transform, card, index);
            cardObject.transform.CopyFrom(cardTemplate.transform);
        }

        /// <summary>
        /// Замена сыгранной карты на карту из колоды
        /// </summary>
        /// <param name="oldCard">Сыгранная карта</param>
        /// <param name="newCard">Новая карта из колоды</param>
        /// <param name="index">Номер карты</param>
        private void OnReplacedCard(Card oldCard, Card newCard, int index)
        {
            var oldCardObject = transform.Find("Card" + index).gameObject;
            oldCardObject.SetActive(false);

            var cardTemplate = CardTemplates[index % CardTemplates.Length];
            var cardObject = CardFactory.CreateCard(transform, newCard, index);
            cardObject.transform.CopyFrom(cardTemplate.transform);
            cardObject.transform.position = CardInitTemplate.transform.position;
            cardObject.SetActive(false);

            var pushTask = History.Push(oldCard, oldCardObject);

            StartCoroutine(OldCardDestroy(pushTask, oldCardObject));
            StartCoroutine(NewCardTranslate(pushTask, cardObject, cardTemplate.transform.position));
        }

        /// <summary>
        /// Корутина, уничтожающая старую карту после выполнения задачи перемещения ее в историю
        /// </summary>
        /// <param name="task">Задача, выполняющая операцию перемещения</param>
        /// <param name="cardObject">Старая карта, перемещаемая в историю</param>
        /// <returns>Корутина</returns>
        private static IEnumerator OldCardDestroy(Task task, GameObject cardObject)
        {
            while (!task.IsCompleted)
                yield return null;

            Destroy(cardObject);
        }

        /// <summary>
        /// Корутина, перемещающая карту из колоды в руку игрока после выполнения задачи перемещения старой карты в 
        /// историю
        /// </summary>
        /// <param name="task">Задача, выполняющая операцию перемещения</param>
        /// <param name="cardObject">Новая карта, перемещаемая из колоды</param>
        /// <param name="position">Положение карты в руке игрока</param>
        /// <returns>Корутина</returns>
        private static IEnumerator NewCardTranslate(Task task, GameObject cardObject, Vector3 position)
        {
            while (!task.IsCompleted)
                yield return null;
            
            cardObject.SetActive(true);

            var cardTranslateScript = cardObject.AddComponent<CardTranslateScript>();
            cardTranslateScript.Initialize(position);
        }
    }
}
