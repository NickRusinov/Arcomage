using System;
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
    /// Представление компонента карт в истории хода
    /// </summary>
    public class HistoryView : View
    {
        [Tooltip("Фабрика создания карт")]
        public HistoryCardFactory HistoryСardFactory;
        
        [Tooltip("Объект, определяющий начальную позицию анимании появления карты и конечную позиция " +
                 "анимации удаления карты")]
        public GameObject СardInitTemplate;
        
        [Tooltip("Коллекция объектов, определяющих позиции, на которых будут расположены карты после " +
                 "их добавления в историю")]
        public GameObject[] СardTemplates;

        /// <summary>
        /// Если значение установлено, при добавлении карты в историю произойдет ее очистка
        /// </summary>
        private bool cleared;

        /// <summary>
        /// Модель представления карты, добавляемой в историю из руки игрока
        /// </summary>
        private CardViewModel pushedCardViewModel;

        /// <summary>
        /// Игровой объект карты, добавляемой в историю из руки игрока
        /// </summary>
        private GameObject pushedCardObject;

        /// <summary>
        /// Задача ожидания завершения анимации перемещения карты в истрорию
        /// </summary>
        private TaskCompletionSource<bool> pushedCardTaskSource = new TaskCompletionSource<bool>();

        /// <summary>
        /// Инициализация компонента
        /// </summary>
        /// <param name="historyViewModel">Модель представления истории хода</param>
        public void Initialize(HistoryViewModel historyViewModel)
        {
            Bind(historyViewModel, h => h.Cards)
                .OnAdded(OnAddedCard)
                .OnCleared(OnClearedCard);
        }

        /// <summary>
        /// Помещает карту из рук игрока в колоду для воспроизведения анимации перемещения сыгранной карты в историю
        /// </summary>
        /// <param name="cardViewModel">Модель представления сыгранной карты</param>
        /// <param name="cardObject">Игровой объект сыгранной карты</param>
        /// <returns>Задача ожидания завершения анимации перемещения карты в историю</returns>
        public Task Push(CardViewModel cardViewModel, GameObject cardObject)
        {
            pushedCardViewModel = cardViewModel;
            pushedCardObject = cardObject;
            pushedCardTaskSource = new TaskCompletionSource<bool>();

            return pushedCardTaskSource.Task;
        }

        /// <summary>
        /// Добавление карты в историю. В случае добавления первой карты в историю, предыдущая история очищается.
        /// Воспроизводится анимация перемещения карты
        /// </summary>
        /// <param name="cardViewModel">Модель представления карты, добавляемой в историю</param>
        /// <param name="index">Номер добавляемой карты</param>
        private void OnAddedCard(HistoryCardViewModel cardViewModel, int index)
        {
            if (cleared)
            {
                foreach (var cardScript in GetComponentsInChildren<HistoryCardView>())
                {
                    var localCardScript = cardScript;

                    var cardTranslateScript = cardScript.gameObject.AddComponent<CardTranslateScript>();
                    cardTranslateScript.Initialize(СardInitTemplate.transform.position);
                    cardTranslateScript.EndedEvent.AddListener(() => 
                        localCardScript.Do(s => Destroy(s.gameObject)));
                }
            }
            
            if (Equals(pushedCardViewModel, cardViewModel))
            {
                var cardTemplate = СardTemplates[index % СardTemplates.Length];
                var cardObject = HistoryСardFactory.CreateCard(transform, cardViewModel, index);
                cardObject.transform.CopyFrom(cardTemplate.transform);
                cardObject.transform.position = pushedCardObject.transform.position;
                
                var cardTranslateScript = cardObject.AddComponent<CardTranslateScript>();
                cardTranslateScript.Initialize(cardTemplate.transform.position);
                cardTranslateScript.EndedEvent.AddListener(() => 
                    pushedCardTaskSource.TrySetResult(true));
            }
            else
            {
                var cardTemplate = СardTemplates[index % СardTemplates.Length];
                var cardObject = HistoryСardFactory.CreateCard(transform, cardViewModel, index);
                cardObject.transform.CopyFrom(cardTemplate.transform);
                cardObject.transform.position = СardInitTemplate.transform.position;

                var cardTranslateScript = cardObject.AddComponent<CardTranslateScript>();
                cardTranslateScript.Initialize(cardTemplate.transform.position);
                pushedCardTaskSource.TrySetResult(true);
            }

            cleared = false;
            pushedCardViewModel = null;
            pushedCardObject = null;
        }

        /// <summary>
        /// Очитска истории. В случае очистки карты убираются не сразу, а только после добавления первой карты в 
        /// новую историю
        /// </summary>
        private void OnClearedCard()
        {
            cleared = true;
            pushedCardViewModel = null;
            pushedCardObject = null;
        }
    }
}
