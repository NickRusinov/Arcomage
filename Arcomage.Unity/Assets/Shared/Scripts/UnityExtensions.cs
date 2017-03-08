using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Arcomage.Unity.Shared.Scripts
{
    public static class UnityExtensions
    {
        public static void CopyFrom(this Transform transform, Transform fromTransform)
        {
            transform.localPosition = fromTransform.localPosition;
            transform.localRotation = fromTransform.localRotation;
            transform.localScale = fromTransform.localScale;
        }

        public static void SetLocalPosition(this Transform transform, float? x = null, float? y = null, float? z = null)
        {
            transform.localPosition = new Vector3(x ?? transform.localPosition.x, y ?? transform.localPosition.y, z ?? transform.localPosition.z);
        }
    }
}
