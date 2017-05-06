using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Unity.Framework;
using Arcomage.Unity.Framework.Bindings;
using Arcomage.Unity.GameScene.ViewModels;
using UnityEngine;
using UnityEngine.UI;

namespace Arcomage.Unity.GameScene.Views
{
    /// <summary>
    /// Представление компонента ресурсов игрока
    /// </summary>
    public class ResourcesView : View<ResourcesViewModel>
    {
        [Tooltip("Текст для вывода имени игрока")]
        public Text PlayerText;

        [Tooltip("Текст для вывода количества шахт")]
        public Text QuarryText;

        [Tooltip("Текст для вывода количества руды")]
        public Text BricksText;

        [Tooltip("Текст для вывода количества монастырей")]
        public Text MagicText;

        [Tooltip("Текст для вывода количества маны")]
        public Text GemsText;

        [Tooltip("Текст для вывода количества казарм")]
        public Text DungeonsText;

        [Tooltip("Текст для вывода количества отрядов")]
        public Text RecruitsText;

        [Tooltip("Система частиц, запускаемая при изменении количества шахт")]
        public ParticleSystem QuarryParticle;

        [Tooltip("Система частиц, запускаемая при изменении количества руды")]
        public ParticleSystem BricksParticle;

        [Tooltip("Система частиц, запускаемая при изменении количества монастырей")]
        public ParticleSystem MagicParticle;

        [Tooltip("Система частиц, запускаемая при изменении количества маны")]
        public ParticleSystem GemsParticle;

        [Tooltip("Система частиц, запускаемая при изменении количества казарм")]
        public ParticleSystem DungeonsParticle;

        [Tooltip("Система частиц, запускаемая при изменении количества отрядов")]
        public ParticleSystem RecruitsParticle;

        protected override void OnViewModel(ResourcesViewModel viewModel)
        {
            Bind(viewModel, r => r.Name)
                .OnChangedAndInit(i => PlayerText.text = i);

            Bind(viewModel, r => r.Quarry)
                .OnChanged(q => QuarryParticle.Play())
                .OnChangedAndInit(q => QuarryText.text = "+" + q);

            Bind(viewModel, r => r.Bricks)
                .OnChanged(q => BricksParticle.Play())
                .OnChangedAndInit(b => BricksText.text = b.ToString());

            Bind(viewModel, r => r.Magic)
                .OnChanged(m => MagicParticle.Play())
                .OnChangedAndInit(m => MagicText.text = "+" + m);

            Bind(viewModel, r => r.Gems)
                .OnChanged(g => GemsParticle.Play())
                .OnChangedAndInit(g => GemsText.text = g.ToString());

            Bind(viewModel, r => r.Dungeons)
                .OnChanged(d => DungeonsParticle.Play())
                .OnChangedAndInit(d => DungeonsText.text = "+" + d);

            Bind(viewModel, r => r.Recruits)
                .OnChanged(r => RecruitsParticle.Play())
                .OnChangedAndInit(r => RecruitsText.text = r.ToString());
        }
    }
}
