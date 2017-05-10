using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Unity.Framework;
using Arcomage.Unity.Framework.Bindings;
using Arcomage.Unity.GameScene.Scripts;
using Arcomage.Unity.GameScene.ViewModels;
using UnityEngine;

namespace Arcomage.Unity.GameScene.Views
{
    /// <summary>
    /// Представление компонента карт в истории хода
    /// </summary>
    public class HistoryView : View<HistoryViewModel>
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
        /// Количество активных анимаций добавления карт в историю из руки игрока
        /// </summary>
        private int addedFromHandAnimationCount;

        /// <summary>
        /// Количество активных анимаций добавления карт в историю из начального положения
        /// </summary>
        private int addedFromInitAnimationCount;

        /// <summary>
        /// Количество активных анимаций удаления карт из истории
        /// </summary>
        private int removedAnimationCount;

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
        private TaskCompletionSource<object> pushedCardTaskSource = new TaskCompletionSource<object>();

        protected override void OnViewModel(HistoryViewModel viewModel)
        {
            Bind(viewModel, h => h.Cards as IList<HistoryCardViewModel>)
                .OnInit((m, i) => StartCoroutine(OnInitCard(m, i)))
                .OnAdded((m, i) => StartCoroutine(OnAddedCard(m, i)))
                .OnReplaced((_, m, i) => StartCoroutine(OnReplacedCard(m, i)))
                .OnReplaced((_, m, i) => StartCoroutine(OnAddedCard(m, i)));
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
            pushedCardTaskSource = new TaskCompletionSource<object>();

            return pushedCardTaskSource.Task;
        }

        /// <summary>
        /// Инициализация карт в истории. Анимации перемещения карт не воспроизводятся.
        /// </summary>
        /// <param name="cardViewModel">Модель представления карты, добавляемой в историю</param>
        /// <param name="index">Номер добавляемой карты</param>
        private IEnumerator OnInitCard(HistoryCardViewModel cardViewModel, int index)
        {
            var cardTemplate = СardTemplates[index % СardTemplates.Length];
            HistoryСardFactory.CreateCard(cardTemplate, cardViewModel);

            yield break;
        }

        /// <summary>
        /// Добавление карты в историю. Воспроизводится анимация перемещения карты
        /// </summary>
        /// <param name="cardViewModel">Модель представления карты, добавляемой в историю</param>
        /// <param name="index">Номер добавляемой карты</param>
        private IEnumerator OnAddedCard(HistoryCardViewModel cardViewModel, int index)
        {
            if (pushedCardViewModel != null && pushedCardViewModel.Id == cardViewModel.Id)
            {
                var cardTemplate = СardTemplates[index % СardTemplates.Length];
                var cardObject = HistoryСardFactory.CreateCard(cardTemplate, cardViewModel);
                cardObject.transform.SetPosition(pushedCardObject.transform);

                while (addedFromInitAnimationCount != 0 || removedAnimationCount != 0)
                    yield return null;

                addedFromHandAnimationCount++;
                
                var cardCanvas = cardObject.AddComponent<Canvas>();
                cardCanvas.overrideSorting = true;

                var cardTranslateScript = cardObject.AddComponent<CardTranslateScript>();
                cardTranslateScript.Initialize(cardTemplate.transform.position);
                cardTranslateScript.EndedEvent.AddListener(cardCanvas.TryDestroy);
                cardTranslateScript.EndedEvent.AddListener(() => pushedCardTaskSource.TrySetResult(null));
                cardTranslateScript.EndedEvent.AddListener(() => addedFromHandAnimationCount--);
            }
            else
            {
                var cardTemplate = СardTemplates[index % СardTemplates.Length];
                var cardObject = HistoryСardFactory.CreateCard(cardTemplate, cardViewModel);
                cardObject.transform.position = СardInitTemplate.transform.position;

                while (addedFromHandAnimationCount != 0 || removedAnimationCount != 0)
                    yield return null;

                addedFromInitAnimationCount++;

                var cardTranslateScript = cardObject.AddComponent<CardTranslateScript>();
                cardTranslateScript.Initialize(cardTemplate.transform.position);
                cardTranslateScript.EndedEvent.AddListener(() => addedFromInitAnimationCount--);
                pushedCardTaskSource.TrySetResult(null);
            }

            pushedCardViewModel = null;
            pushedCardObject = null;
        }

        /// <summary>
        /// Замена карт истории старых на новые. Воспроизводится анимация перемещения всех карт в истории за пределы 
        /// игрового поля.
        /// </summary>
        /// <param name="cardViewModel">Модель представления карты, добавляемой в историю</param>
        /// <param name="index">Номер добавляемой карты</param>
        private IEnumerator OnReplacedCard(HistoryCardViewModel cardViewModel, int index)
        {
            var historyCardViewCollection = GetComponentsInChildren<HistoryCardView>();

            removedAnimationCount++;

            while (addedFromHandAnimationCount != 0 || addedFromInitAnimationCount != 0)
                yield return null;

            foreach (var cardScript in historyCardViewCollection.Where(v => v))
            {
                var localCardScript = cardScript;
                
                var cardTranslateScript = localCardScript.gameObject.AddComponent<CardTranslateScript>();
                cardTranslateScript.Initialize(СardInitTemplate.transform.position);
                cardTranslateScript.EndedEvent.AddListener(localCardScript.TryDestroyObject);
            }

            removedAnimationCount--;
        }
    }
}
