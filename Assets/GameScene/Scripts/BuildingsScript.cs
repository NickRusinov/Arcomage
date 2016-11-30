using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Rules;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class BuildingsScript : View
    {
        [Tooltip("Текст для вывода высоты башни")]
        public TextMesh TowerText;

        [Tooltip("Текст для вывода высоты стены")]
        public TextMesh WallText;

        [Tooltip("Спрайт башни")]
        public SpriteRenderer TowerImage;

        [Tooltip("Спрайт стены")]
        public SpriteRenderer WallImage;

        public void Initialize(Buildings buildings, ClassicRule rule)
        {
            Bind(buildings, b => b.Tower)
                .OnChangedAndInit(t => TowerText.text = t.ToString())
                .OnChangedAndInit(t => TowerImage.transform.SetLocalPosition(y : -330f + Math.Min(180f, 180f * t / rule.MaxTower)))
                .OnChangedAndInit(t => TowerImage.material.SetFloat("_Length", 1f - (150f + Math.Min(180f, 180f * t / rule.MaxTower) / TowerImage.sprite.texture.height)));

            Bind(buildings, b => b.Wall)
                .OnChangedAndInit(w => WallText.text = w.ToString())
                .OnChangedAndInit(w => WallImage.transform.SetLocalPosition(y: -430f + Math.Min(280f, 280f * w / rule.MaxTower)))
                .OnChangedAndInit(w => WallImage.material.SetFloat("_Length", 1f - (50f + Math.Min(280f, 280f * w / rule.MaxTower) / WallImage.sprite.texture.height)));
        }
    }
}
