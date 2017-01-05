using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Rules;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;

namespace Arcomage.Unity.GameScene.Views
{
    public class BuildingsView : View
    {
        [Tooltip("Текст для вывода высоты башни")]
        public TextMesh TowerText;

        [Tooltip("Текст для вывода высоты стены")]
        public TextMesh WallText;

        [Tooltip("Система частиц, запускаемая при изменении высоты башни")]
        public ParticleSystem TowerParticle;

        [Tooltip("Система частиц, запускаемая при изменении высоты стены")]
        public ParticleSystem WallParticle;

        [Tooltip("Спрайт башни")]
        public SpriteRenderer TowerImage;

        [Tooltip("Спрайт стены")]
        public SpriteRenderer WallImage;

        public void Initialize(Buildings buildings, ClassicRuleInfo ruleInfo)
        {
            Bind(buildings, b => b.Tower)
                .OnChanged(t => TowerParticle.Play())
                .OnChangedAndInit(t => TowerText.text = t.ToString())
                .OnChangedAndInit(t => TowerImage.transform.SetLocalPosition(y : -330f + Math.Min(180f, 180f * t / ruleInfo.MaxTower)))
                .OnChangedAndInit(t => TowerImage.material.SetFloat("_Length", 1f - (150f + Math.Min(180f, 180f * t / ruleInfo.MaxTower)) / TowerImage.sprite.texture.height));

            Bind(buildings, b => b.Wall)
                .OnChanged(w => WallParticle.Play())
                .OnChangedAndInit(w => WallText.text = w.ToString())
                .OnChangedAndInit(w => WallImage.transform.SetLocalPosition(y: -460f + Math.Min(280f, 280f * w / ruleInfo.MaxTower)))
                .OnChangedAndInit(w => WallImage.material.SetFloat("_Length", 1f - (20f + Math.Min(280f, 280f * w / ruleInfo.MaxTower)) / WallImage.sprite.texture.height));
        }
    }
}
