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
    public class HistoryCardView : View
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

        /// <summary>
        /// Порядковый номер карты в истории хода
        /// </summary>
        [NonSerialized]
        public int Index;

        /// <summary>
        /// Инициализация компонента
        /// </summary>
        /// <param name="historyCard">Модель представления карты в истории хода</param>
        public void Initialize(HistoryCardViewModel historyCardViewModel)
        {
            Bind(historyCardViewModel.Identifier)
                .OnInit(i => ForegroundImage.sprite = Resources.Load<Sprite>("Card" + i + "Image"))
                .OnInit(i => NameText.text = LanguageManager.Instance.GetTextValue("Card" + i + "Name"))
                .OnInit(i => DescriptionText.text = LanguageManager.Instance.GetTextValue("Card" + i + "Description"));

            Bind(historyCardViewModel, c => c.Kind)
                .OnChangedAndInit(r => BackgroundImage.sprite = Resources.Load<Sprite>("Card" + r + "Image"));

            Bind(historyCardViewModel, c => c.Price)
                .OnChangedAndInit(p => PriceText.text = p.ToString());

            Bind(historyCardViewModel, c => c.IsPlayed)
                .OnChangedAndInit(b => DiscardText.gameObject.SetActive(!b))
                .OnChangedAndInit(b => DiscardText.text = LanguageManager.Instance.GetTextValue("CardDiscardText"));
        }
    }
}