using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class CardTranslateScript : Script
    {
        [SerializeField]
        [Tooltip("Скрость анимации перемещения")]
        private float speed = 500f;

        private Vector3 position;

        private Action<GameObject> onTranslated;

        public void Initialize(Vector3 position, Action<GameObject> onTranslated = null)
        {
            this.position = position;
            this.onTranslated = onTranslated;
        }

        public override void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * speed);

            if (transform.position == position)
            {
                if (onTranslated != null)
                    onTranslated.Invoke(gameObject);

                Destroy(this);
            }
        }
    }
}