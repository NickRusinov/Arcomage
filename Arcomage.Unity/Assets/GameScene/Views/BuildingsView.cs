using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Unity.GameScene.ViewModels;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;

namespace Arcomage.Unity.GameScene.Views
{
    /// <summary>
    /// Представление компонента строений игрока
    /// </summary>
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

        /// <summary>
        /// Инициализация компонента
        /// </summary>
        /// <param name="buildingsViewModel">Модель представления строений игрока</param>
        public void Initialize(BuildingsViewModel buildingsViewModel)
        {
            Bind(buildingsViewModel, b => b.Tower)
                .OnChanged(t => TowerParticle.Play())
                .OnChangedAndInit(t => TowerText.text = t.ToString())
                .OnChangedAndInit(t => TowerImage.transform.SetLocalPosition(y: -330f + Math.Min(180f, 180f * t / buildingsViewModel.MaxTower)))
                .OnChangedAndInit(t => TowerImage.material.SetFloat("_Length", 1f - (150f + Math.Min(180f, 180f * t / buildingsViewModel.MaxTower)) / TowerImage.sprite.texture.height));

            Bind(buildingsViewModel, b => b.Wall)
                .OnChanged(w => WallParticle.Play())
                .OnChangedAndInit(w => WallText.text = w.ToString())
                .OnChangedAndInit(w => WallImage.transform.SetLocalPosition(y: -460f + Math.Min(280f, 280f * w / buildingsViewModel.MaxWall)))
                .OnChangedAndInit(w => WallImage.material.SetFloat("_Length", 1f - (20f + Math.Min(280f, 280f * w / buildingsViewModel.MaxWall)) / WallImage.sprite.texture.height));
        }
    }
}
