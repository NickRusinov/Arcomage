using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Unity.GameScene.ViewModels;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Arcomage.Unity.GameScene.Views
{
    /// <summary>
    /// Представление компонента строений игрока
    /// </summary>
    public class BuildingsView : View<BuildingsViewModel>
    {
        [Tooltip("Текст для вывода высоты башни")]
        public Text TowerText;

        [Tooltip("Текст для вывода высоты стены")]
        public Text WallText;

        [Tooltip("Система частиц, запускаемая при изменении высоты башни")]
        public ParticleSystem TowerParticle;

        [Tooltip("Система частиц, запускаемая при изменении высоты стены")]
        public ParticleSystem WallParticle;

        [Tooltip("Спрайт башни")]
        public Image TowerImage;

        [Tooltip("Спрайт стены")]
        public Image WallImage;

        protected override void OnViewModel(BuildingsViewModel viewModel)
        {
            Bind(viewModel, b => b.Tower)
                .OnChanged(t => TowerParticle.Play())
                .OnChangedAndInit(t => TowerText.text = t.ToString())
                .OnChangedAndInit(t => TowerImage.transform.SetAnchor(
                    minY: Mathf.Min(-.2f, -.75f + .55f * t / viewModel.MaxTower ?? 50),
                    maxY: Mathf.Min(+.8f, +.25f + .55f * t / viewModel.MaxTower ?? 50)));

            Bind(viewModel, b => b.Wall)
                .OnChanged(w => WallParticle.Play())
                .OnChangedAndInit(w => WallText.text = w.ToString())
                .OnChangedAndInit(w => WallImage.transform.SetAnchor(
                    minY: Mathf.Min(-.2f, -.85f + .65f * w / viewModel.MaxWall ?? 50),
                    maxY: Mathf.Min(+.8f, +.15f + .65f * w / viewModel.MaxWall ?? 50)));
        }
    }
}
