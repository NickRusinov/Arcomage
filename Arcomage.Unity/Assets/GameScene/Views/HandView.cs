using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Unity.GameScene.Factories;
using Arcomage.Unity.GameScene.Scripts;
using Arcomage.Unity.GameScene.ViewModels;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;

namespace Arcomage.Unity.GameScene.Views
{
    /// <summary>
    /// Представление компонента карт на руках игрока
    /// </summary>
    public class HandView : View<HandViewModel>
    {
        [Tooltip("Фабрика создания карт")]
        public CardFactory CardFactory;

        [Tooltip("Компонент истории текущего хода")]
        public HistoryView History;

        [Tooltip("Объект, определяющий начальную позицию анимации появления карты")]
        public GameObject CardInitTemplate;
        
        [Tooltip("Коллекция объектов, определяющих положение, вращение и масштаб карт")]
        public GameObject[] CardTemplates;

        protected override void OnViewModel(HandViewModel viewModel)
        {
            Bind(viewModel, h => h.Cards)
                .OnInit(OnInitializeCard)
                .OnAdded(OnInitializeCard)
                .OnReplaced(OnReplacedCard);
        }

        /// <summary>
        /// Инициализация карты в начале игры
        /// </summary>
        /// <param name="card">Модель представления карты</param>
        /// <param name="index">Номер карты в руке</param>
        private void OnInitializeCard(CardViewModel cardViewModel, int index)
        {
            var cardTemplate = CardTemplates[index % CardTemplates.Length];
            var cardObject = CardFactory.CreateCard(transform, cardViewModel);
            cardObject.transform.CopyFrom(cardTemplate.transform);
        }

        /// <summary>
        /// Замена сыгранной карты на карту из колоды
        /// </summary>
        /// <param name="oldCard">Модель представления сыгранной карты</param>
        /// <param name="newCard">Модель представления новой карты из колоды</param>
        /// <param name="index">Номер карты</param>
        private void OnReplacedCard(CardViewModel oldCardViewModel, CardViewModel newCardViewModel, int index)
        {
            var oldCardObject = transform.Find("Card" + index).gameObject;
            oldCardObject.SetActive(false);

            var cardTemplate = CardTemplates[index % CardTemplates.Length];
            var cardObject = CardFactory.CreateCard(transform, newCardViewModel);
            cardObject.transform.CopyFrom(cardTemplate.transform);
            cardObject.transform.position = CardInitTemplate.transform.position;
            cardObject.SetActive(false);

            var pushTask = History.Push(oldCardViewModel, oldCardObject);

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
            yield return new TaskYieldInstruction(task);

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
            yield return new TaskYieldInstruction(task);
            
            cardObject.SetActive(true);

            var cardTranslateScript = cardObject.AddComponent<CardTranslateScript>();
            cardTranslateScript.Initialize(position);
        }
    }
}
