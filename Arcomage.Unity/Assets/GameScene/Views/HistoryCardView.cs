using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Unity.GameScene.ViewModels;
using Arcomage.Unity.Shared.Scripts;
using SmartLocalization;
using UnityEngine;

namespace Arcomage.Unity.GameScene.Views
{
    /// <summary>
    /// Представление компонента игровой карты в истории хода
    /// </summary>
    public class HistoryCardView : View<HistoryCardViewModel>
    {
        [Tooltip("Текст для вывода названия карты")]
        public TextMesh NameText;

        [Tooltip("Текст для вывода описания карты")]
        public TextMesh DescriptionText;

        [Tooltip("Текст для вывода стоимости карты")]
        public TextMesh PriceText;

        [Tooltip("Текст для вывода сброшенности карты")]
        public TextMesh DiscardText;

        [Tooltip("Спрайт фона карты")]
        public SpriteRenderer BackgroundImage;

        [Tooltip("Спрайт изображения карты")]
        public SpriteRenderer ForegroundImage;

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