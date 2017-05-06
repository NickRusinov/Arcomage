using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Arcomage.Unity.Framework.Scripts
{
    public class ScaleScript : MonoBehaviour
    {
        [Tooltip("Требуемая ширина экрана")]
        public float AspectWidth;

        [Tooltip("Требуемая высота экрана")]
        public float AspectHeight;

        public void Update()
        {
            if (1f * Screen.height / Screen.width >= AspectHeight / AspectWidth)
                Camera.main.orthographicSize = .5f * AspectWidth * Screen.height / Screen.width;
            else
                Camera.main.orthographicSize = .5f * AspectHeight;
        }
    }
}
