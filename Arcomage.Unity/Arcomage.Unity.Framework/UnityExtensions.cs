using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Arcomage.Unity.Framework
{
    public static class UnityExtensions
    {
        public static void CopyFrom(this Transform transform, Transform fromTransform)
        {
            transform.localPosition = fromTransform.localPosition;
            transform.localRotation = fromTransform.localRotation;
            transform.localScale = fromTransform.localScale;
        }

        public static void CopyFrom(this RectTransform transform, RectTransform fromTransform)
        {
            transform.CopyFrom((Transform)fromTransform);
            transform.anchorMin = fromTransform.anchorMin;
            transform.anchorMax = fromTransform.anchorMax;
            transform.offsetMin = fromTransform.offsetMin;
            transform.offsetMax = fromTransform.offsetMax;
            transform.pivot = fromTransform.pivot;
        }

        public static void SetAnchor(this Transform transform, float? minX = null, float? maxX = null, float? minY = null, float? maxY = null)
        {
            var rectTransform = (RectTransform)transform;
            rectTransform.anchorMin = new Vector2(minX ?? rectTransform.anchorMin.x, minY ?? rectTransform.anchorMin.y);
            rectTransform.anchorMax = new Vector2(maxX ?? rectTransform.anchorMax.x, maxY ?? rectTransform.anchorMax.y);
        }

        public static void SetPosition(this Transform transform, Transform fromTransform)
        {
            var rectTransform = (RectTransform)transform;
            var rectFromTransform = (RectTransform)fromTransform;
            transform.position = fromTransform.position + Vector3.Scale(rectFromTransform.rect.size, rectTransform.pivot - rectFromTransform.pivot);
        }

        public static void TryDestroyObject(this Component component)
        {
            if (component != null && component.gameObject != null)
                Object.Destroy(component.gameObject);
        }

        public static void TryDestroy(this Object @object)
        {
            if (@object != null)
                Object.Destroy(@object);
        }
    }
}
