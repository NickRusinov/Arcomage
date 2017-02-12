using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Unity.GameScene.Scripts;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;
using Resources = Arcomage.Domain.Entities.Resources;

namespace Arcomage.Unity.GameScene.Views
{
    public class ResourcesView : View
    {
        [Tooltip("Текст для вывода имени игрока")]
        public TextMesh PlayerText;

        [Tooltip("Текст для вывода количества шахт")]
        public TextMesh QuarryText;

        [Tooltip("Текст для вывода количества руды")]
        public TextMesh BricksText;

        [Tooltip("Текст для вывода количества монастырей")]
        public TextMesh MagicText;

        [Tooltip("Текст для вывода количества маны")]
        public TextMesh GemsText;

        [Tooltip("Текст для вывода количества казарм")]
        public TextMesh DungeonsText;

        [Tooltip("Текст для вывода количества отрядов")]
        public TextMesh RecruitsText;

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

        public void Initialize(PlayerKind playerKind, Resources resources)
        {
            Bind(playerKind, p => p.GetName())
                .OnChangedAndInit(i => PlayerText.text = i);

            Bind(resources, r => r.Quarry)
                .OnChanged(q => QuarryParticle.Play())
                .OnChangedAndInit(q => QuarryText.text = "+" + q);

            Bind(resources, r => r.Bricks)
                .OnChanged(q => BricksParticle.Play())
                .OnChangedAndInit(b => BricksText.text = b.ToString());

            Bind(resources, r => r.Magic)
                .OnChanged(m => MagicParticle.Play())
                .OnChangedAndInit(m => MagicText.text = "+" + m);

            Bind(resources, r => r.Gems)
                .OnChanged(g => GemsParticle.Play())
                .OnChangedAndInit(g => GemsText.text = g.ToString());

            Bind(resources, r => r.Dungeons)
                .OnChanged(d => DungeonsParticle.Play())
                .OnChangedAndInit(d => DungeonsText.text = "+" + d);

            Bind(resources, r => r.Recruits)
                .OnChanged(r => RecruitsParticle.Play())
                .OnChangedAndInit(r => RecruitsText.text = r.ToString());
        }
    }
}
