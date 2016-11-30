using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;
using Resources = Arcomage.Domain.Entities.Resources;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class ResourcesScript : View
    {
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

        public void Initialize(Resources resources)
        {
            Bind(resources, r => r.Quarry)
                .OnChangedAndInit(q => QuarryText.text = "+" + q);

            Bind(resources, r => r.Bricks)
                .OnChangedAndInit(b => BricksText.text = b.ToString());

            Bind(resources, r => r.Magic)
                .OnChangedAndInit(m => MagicText.text = "+" + m);

            Bind(resources, r => r.Gems)
                .OnChangedAndInit(g => GemsText.text = g.ToString());

            Bind(resources, r => r.Dungeons)
                .OnChangedAndInit(d => DungeonsText.text = "+" + d);

            Bind(resources, r => r.Recruits)
                .OnChangedAndInit(r => RecruitsText.text = r.ToString());
        }
    }
}
