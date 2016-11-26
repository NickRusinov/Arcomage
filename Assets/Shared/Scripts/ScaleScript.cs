using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Arcomage.Unity.Shared.Scripts
{
    public class ScaleScript : Script
    {
        [SerializeField]
        [Tooltip("Требуемая ширина экрана")]
        public float AspectWidth;

        [SerializeField]
        [Tooltip("Требуемая выстоа экрана")]
        public float AspectHeight;

        public override void Update()
        {
            //var realHeight = Camera.main.pixelHeight;
            //var realWidth = Camera.main.pixelWidth;

            //Debug.Log(realHeight + " " + realWidth);

            //var scale = new Vector2(realWidth / AspectWidth, realHeight / AspectHeight);
            //scale = new Vector2(Math.Min(scale.x, scale.y), Math.Min(scale.x, scale.y));

            //transform.localScale = new Vector3(scale.x, scale.y, transform.localScale.z);

            Camera.main.orthographicSize = 1280f * Screen.height / Screen.width * 0.5f;
        }
    }
}
