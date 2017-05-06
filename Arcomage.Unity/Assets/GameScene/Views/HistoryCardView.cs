using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Unity.Framework;
using Arcomage.Unity.Framework.Bindings;
using Arcomage.Unity.GameScene.ViewModels;
using SmartLocalization;
using UnityEngine;
using UnityEngine.UI;

namespace Arcomage.Unity.GameScene.Views
{
    /// <summary>
    /// Представление компонента игровой карты в истории хода
    /// </summary>
    public class HistoryCardView : View<HistoryCardViewModel>
    {
        [Tooltip("Текст для вывода названия карты")]
        public Text NameText;

        [Tooltip("Текст для вывода описания карты")]
        public Text DescriptionText;

        [Tooltip("Текст для вывода стоимости карты")]
        public Text PriceText;

        [Tooltip("Текст для вывода сброшенности карты")]
        public Text DiscardText;

        [Tooltip("Спрайт фона карты")]
        public Image BackgroundImage;

        [Tooltip("Спрайт изображения карты")]
        public Image ForegroundImage;

        protected override void OnViewModel(HistoryCardViewModel viewModel)
        {
            Bind(viewModel.Identifier)
                .OnInit(i => ForegroundImage.sprite = Resources.Load<Sprite>("Card" + i + "Image"))
                .OnInit(i => NameText.text = LanguageManager.Instance.GetTextValue("Card" + i + "Name"))
                .OnInit(i => DescriptionText.text = LanguageManager.Instance.GetTextValue("Card" + i + "Description"));

            Bind(viewModel, c => c.Kind)
                .OnChangedAndInit(r => BackgroundImage.sprite = Resources.Load<Sprite>("Card" + r + "Image"));

            Bind(viewModel, c => c.Price)
                .OnChangedAndInit(p => PriceText.text = p.ToString());

            Bind(viewModel, c => c.IsPlayed)
                .OnChangedAndInit(b => DiscardText.gameObject.SetActive(!b))
                .OnChangedAndInit(b => DiscardText.text = LanguageManager.Instance.GetTextValue("CardDiscardText"));
        }
    }
}