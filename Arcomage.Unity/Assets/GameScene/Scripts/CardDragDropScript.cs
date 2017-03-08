using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Unity.GameScene.Commands;
using Arcomage.Unity.GameScene.Views;
using UnityEngine;

namespace Arcomage.Unity.GameScene.Scripts
{
    /// <summary>
    /// Скрипт, позволяющий карте быть перемещаемой игроком
    /// </summary>
    [RequireComponent(typeof(CardView), typeof(PlayCardCommand), typeof(DiscardCardCommand))]
    public class CardDragDropScript : MonoBehaviour
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
        
        public void Update()
        {
            if (GameSceneScript.Pause)
                return;

            if (Input.GetMouseButton(0) && draggingItem)
            {
                Vector2 inputPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                transform.position = inputPosition + touchOffset;
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -0.50f);
            }

            if (Input.GetMouseButton(0) && !draggingItem && !globalDraggingItem)
            {
                Vector2 inputPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
                var hit = Physics2D.RaycastAll(inputPosition, inputPosition).FirstOrDefault();

                if (hit.transform != null && hit.transform.gameObject == transform.gameObject)
                {
                    draggingItem = globalDraggingItem = true;
                    initialPosition = hit.transform.position;
                    touchOffset = (Vector2)hit.transform.position - inputPosition;
                }
            }

            if (!Input.GetMouseButton(0) && draggingItem)
            {
                draggingItem = globalDraggingItem = false;
                var index = GetComponent<CardView>().Index;

                var playCommand = GetComponent<PlayCardCommand>();
                if (transform.position.y - initialPosition.y >= + 25f)
                    if (playCommand.CanExecute(index))
                        playCommand.Execute(index);

                var discardCommand = GetComponent<DiscardCardCommand>();
                if (transform.position.y - initialPosition.y <= - 25f)
                    if (discardCommand.CanExecute(index))
                        discardCommand.Execute(index);

                StartCoroutine(CardTranslate(gameObject, initialPosition));
            }
        }

        /// <summary>
        /// Выполняет перемещение карты в ее исходное положение
        /// </summary>
        /// <param name="cardObject">Игровой объект карты</param>
        /// <param name="position">Исходное положение карты</param>
        /// <returns>Корутина</returns>
        private static IEnumerator CardTranslate(GameObject cardObject, Vector3 position)
        {
            yield return null;
        
            var cardTranslateScript = cardObject.AddComponent<CardTranslateScript>();
            cardTranslateScript.Initialize(position);
        }
    }
}
