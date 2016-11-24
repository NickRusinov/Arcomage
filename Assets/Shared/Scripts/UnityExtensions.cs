using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Arcomage.Unity.Shared.Scripts
{
    public static class UnityExtensions
    {
        public static void UpdateText(this MonoBehaviour monoBehaviour, string name, string value)
        {
            monoBehaviour.ResolveScript<TextMesh>(name).text = value;
        }

        public static void UpdateText<T>(this MonoBehaviour monoBehaviour, string name, T value)
        {
            monoBehaviour.ResolveScript<TextMesh>(name).text = value.ToString();
        }

        public static void UpdateLocalization(this MonoBehaviour monoBehaviour, string name, string value)
        {
            monoBehaviour.ResolveScript<LocalizationScript>(name).Identifier = value;
        }

        public static void UpdateSprite(this MonoBehaviour monoBehaviour, string name, Sprite sprite)
        {
            monoBehaviour.ResolveScript<SpriteRenderer>(name).sprite = sprite;
        }

        public static void UpdateSpriteColor(this MonoBehaviour monoBehaviour, string name, Color color)
        {
            monoBehaviour.ResolveScript<SpriteRenderer>(name).color = color;
        }

        public static void UpdateSpriteHeight(this MonoBehaviour monoBehaviour, string name, float height)
        {
            var spriteRenderer = monoBehaviour.ResolveScript<SpriteRenderer>(name);
            spriteRenderer.material.SetFloat("_Length", 1f - height / spriteRenderer.sprite.texture.height);
        }

        public static void UpdateY(this MonoBehaviour monoBehaviour, string name, float y)
        {
            var transform = monoBehaviour.transform.Find(name).transform;
            transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);
        }

        public static T ResolveScript<T>(this MonoBehaviour monoBehaviour, string name)
        {
            return monoBehaviour.transform.Find(name).gameObject.GetComponent<T>();
        }

        public static IEnumerable<Transform> FindByTag(this Transform transform, string tag)
        {
            return transform.Cast<Transform>().Where(t => t.tag == tag);
        }

        public static void CopyFrom(this Transform transform, Transform fromTransform)
        {
            transform.localPosition = fromTransform.localPosition;
            transform.localRotation = fromTransform.localRotation;
            transform.localScale = fromTransform.localScale;
        }
    }
}
