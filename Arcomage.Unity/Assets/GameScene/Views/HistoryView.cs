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

        protected override void OnViewModel(HistoryViewModel viewModel)
        {
            Bind(viewModel, h => h.Cards as IList<HistoryCardViewModel>)
                .OnAdded(OnAddedCard)
                .OnReplaced((_, cardViewModel, index) => OnReplacedCard(cardViewModel, index))
                .OnReplaced((_, cardViewModel, index) => OnAddedCard(cardViewModel, index));
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
            if (pushedCardViewModel != null && pushedCardViewModel.Id == cardViewModel.Id)
            {
                var cardTemplate = СardTemplates[index % СardTemplates.Length];
                var cardObject = HistoryСardFactory.CreateCard(transform, cardViewModel);
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
                var cardObject = HistoryСardFactory.CreateCard(transform, cardViewModel);
                cardObject.transform.CopyFrom(cardTemplate.transform);
                cardObject.transform.position = СardInitTemplate.transform.position;

                var cardTranslateScript = cardObject.AddComponent<CardTranslateScript>();
                cardTranslateScript.Initialize(cardTemplate.transform.position);
                pushedCardTaskSource.TrySetResult(true);
            }
            
            pushedCardViewModel = null;
            pushedCardObject = null;
        }

        private void OnReplacedCard(HistoryCardViewModel cardViewModel, int index)
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
    }
}
