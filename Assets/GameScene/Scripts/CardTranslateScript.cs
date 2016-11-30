using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class CardTranslateScript : MonoBehaviour
    {
        [Tooltip("Событие завершения перемещения")]
        public UnityEvent EndedEvent = new UnityEvent();

        [Tooltip("Скрость анимации перемещения")]
        public float Speed = 1000f;

        private Vector3 position;

        public void Initialize(Vector3 position)
        {
            this.position = position;
        }

        public void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * Speed);

            if (transform.position == position)
            {
                EndedEvent.Invoke();
                Destroy(this);
            }
        }
    }
}