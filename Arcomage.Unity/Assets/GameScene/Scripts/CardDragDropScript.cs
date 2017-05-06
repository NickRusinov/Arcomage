using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Arcomage.Unity.Framework;
using Arcomage.Unity.GameScene.Requests;
using Arcomage.Unity.GameScene.Views;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Arcomage.Unity.GameScene.Scripts
{
    /// <summary>
    /// Скрипт, позволяющий карте быть перемещаемой игроком
    /// </summary>
    [RequireComponent(typeof(CardView))]
    public class CardDragDropScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        /// <summary>
        /// В один момент времени только одна карта может быть перемещаемая игроком
        /// </summary>
        private static bool globalDraggingItem;

        /// <summary>
        /// Является ли карта в данный момент перемещаемой игроком
        /// </summary>
        private bool draggingItem;

        /// <summary>
        /// Смещение карты относительно ее исходного положения
        /// </summary>
        private Vector2 touchOffset;

        /// <summary>
        /// Начальное положение карты до ее перемещения
        /// </summary>
        private Vector3 initialPosition;
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            Vector2 position;
            if (!draggingItem && !globalDraggingItem && RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)transform.parent, eventData.position, Camera.main, out position))
            {
                draggingItem = globalDraggingItem = true;

                initialPosition = transform.position;
                touchOffset = (Vector2)transform.localPosition - position;

                transform.SetAsLastSibling();
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 position;
            if (draggingItem && RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)transform.parent, eventData.position, Camera.main, out position))
            {
                transform.localPosition = position + touchOffset;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (draggingItem)
            {
                draggingItem = globalDraggingItem = false;
                
                var cardViewModel = GetComponent<CardView>().ViewModel;
                var cardExecuteTask = (Task)TaskEx.FromResult<object>(null);

                if (transform.position.y - initialPosition.y >= +25f && cardViewModel.IsPlay)
                    cardExecuteTask = Global.Mediator.Send(new PlayCardRequest(cardViewModel.Index), CancellationToken.None);

                if (transform.position.y - initialPosition.y <= -25f && cardViewModel.IsDiscard)
                    cardExecuteTask = Global.Mediator.Send(new DiscardCardRequest(cardViewModel.Index), CancellationToken.None);

                StartCoroutine(CardTranslate(gameObject, initialPosition, cardExecuteTask));
            }
        }

        /// <summary>
        /// Выполняет перемещение карты в ее исходное положение
        /// </summary>
        /// <param name="cardObject">Игровой объект карты</param>
        /// <param name="position">Исходное положение карты</param>
        /// <returns>Корутина</returns>
        private static IEnumerator CardTranslate(GameObject cardObject, Vector3 position, Task cardExecuteTask)
        {
            yield return new TaskYieldInstruction(cardExecuteTask);
            yield return null;

            var cardTranslateScript = cardObject.AddComponent<CardTranslateScript>();
            cardTranslateScript.Initialize(position);
        }
    }
}
