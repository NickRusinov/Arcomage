using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.Configuration;
using Arcomage.Unity.Framework;
using UnityEngine;

namespace Arcomage.Unity
{
    public class Program
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Main()
        {
            Debug.Log("Инициализация игры");

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            var autofacConfiguration = new AutofacConfiguration();
            var container = autofacConfiguration.Configure();

            Debug.Log("Время на инициализацию игры: " + stopwatch.Elapsed);

            Scene.Initialize(container);
        }
    }
}
