using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class CardDragDropScript : ObservableScript
    {
        private static bool globalDraggingItem;

        private Command playCommand;

        private Command discardCommand;
    
        private int index;

        private bool draggingItem;

        private Vector2 touchOffset;

        private Vector3 initialPosition;

        private Vector3 latestPosition;

        public void Initialize(Command playCommand, Command discardCommand, int index)
        {
            this.playCommand = playCommand;
            this.discardCommand = discardCommand;
            this.index = index;

            Initialize(
                playCommand.Observable(c => c.CanExecute(index),
                    () => this.UpdateSpriteColor("BackgroundImage", new Color(1, 1, 1, 1)),
                    () => this.UpdateSpriteColor("BackgroundImage", new Color(.5f, .5f, .5f, .5f))),
                playCommand.Observable(c => c.CanExecute(index),
                    () => this.UpdateSpriteColor("ForegroundImage", new Color(1, 1, 1, 1)),
                    () => this.UpdateSpriteColor("ForegroundImage", new Color(.5f, .5f, .5f, .5f))));
        }

        public Vector3 ResolveLatestPosition()
        {
            return latestPosition;
        }

        public override void Update()
        {
            base.Update();

            if (Input.GetMouseButton(0) && draggingItem)
            {
                Vector2 inputPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                transform.position = inputPosition + touchOffset;
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -2);
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
            
                if (transform.position.y - initialPosition.y >= + 25f)
                    if (playCommand.CanExecute(index))
                        playCommand.Execute(index);
            
                if (transform.position.y - initialPosition.y <= - 25f)
                    if (discardCommand.CanExecute(index))
                        discardCommand.Execute(index);

                latestPosition = transform.position;

                StartCoroutine(TranslatePosition(gameObject, initialPosition));
            }
        }

        private static IEnumerator TranslatePosition(GameObject cardObject, Vector3 position)
        {
            yield return null;
        
            cardObject.AddComponent<CardTranslateScript>().Initialize(position);
        }
    }
}
