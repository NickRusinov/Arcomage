using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.Framework;
using Arcomage.Unity.Framework.Bindings;
using Arcomage.Unity.GameScene.ViewModels;
using UnityEngine;
using UnityEngine.UI;

namespace Arcomage.Unity.GameScene.Views
{
    public class TimerView : View<TimerViewModel>
    {
        [Tooltip("Текст для вывода оставшегося времени хода в секундах")]
        public Text TimeText;

        [Tooltip("Цвет текста для вывода достаточного оставшегося времени хода")]
        public Color RegularTimeColor;

        [Tooltip("Цвет текста для вывода истекающего оставшегося времени хода")]
        public Color WarningTimeColor;

        private float lastUpdateTime = -1;

        protected override void OnViewModel(TimerViewModel viewModel)
        {
            Bind(viewModel, t => t.TimeRest)
                .OnChangedAndInit(t => TimeText.text = ((int)t).ToString())
                .OnChangedAndInit(t => TimeText.gameObject.SetActive(t >= 0))
                .OnChangedAndInit(t => lastUpdateTime = Time.timeSinceLevelLoad)
                .OnChangedAndInit(t => t >= 6, t => TimeText.color = RegularTimeColor)
                .OnChangedAndInit(t => t < 6, t => TimeText.color = WarningTimeColor);
        }

        public void OnEnable()
        {
            InvokeRepeating("UpdateTimer", 0, 0.5f);
        }

        public void OnDisable()
        {
            CancelInvoke("UpdateTimer");
        }

        public void UpdateTimer()
        {
            if (lastUpdateTime >= 0 && ViewModel != null && ViewModel.TimeRest >= 0 && !GameScene.Pause)
            {
                var deltaUpdateTime = Time.timeSinceLevelLoad - lastUpdateTime;
                ViewModel.TimeRest = Math.Max(0, ViewModel.TimeRest - deltaUpdateTime);
            }
        }
    }
}
