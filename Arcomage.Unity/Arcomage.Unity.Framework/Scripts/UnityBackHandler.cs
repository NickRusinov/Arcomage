using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace Arcomage.Unity.Framework.Scripts
{
    public class UnityBackHandler : MonoBehaviour
    {
        [Tooltip(@"Событие обработки нажатия кнопки ""Назад""")]
        public UnityEvent BackHandler;

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                BackHandler.Invoke();
        }
    }
}
