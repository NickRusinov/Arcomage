using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Unity.GameScene.Scripts;
using Arcomage.Unity.Shared.Scripts;
using SmartLocalization;
using UnityEngine;

namespace Arcomage.Unity.GameScene.Views
{
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

        [NonSerialized]
        public int Index;

        public void Initialize(HistoryCard historyCard)
        {
            Bind(historyCard.Card.GetIdentifier())
                .OnInit(i => ForegroundImage.sprite = UnityEngine.Resources.Load<Sprite>("Card" + i + "Image"))
                .OnInit(i => NameText.text = LanguageManager.Instance.GetTextValue("Card" + i + "Name"))
                .OnInit(i => DescriptionText.text = LanguageManager.Instance.GetTextValue("Card" + i + "Description"));

            Bind(historyCard, c => c.Card.Kind)
                .OnChangedAndInit(r => BackgroundImage.sprite = UnityEngine.Resources.Load<Sprite>("Card" + r + "Image"));

            Bind(historyCard, c => c.Card.Price)
                .OnChangedAndInit(p => PriceText.text = p.ToString());

            Bind(historyCard, c => c.IsPlayed)
                .OnChangedAndInit(b => DiscardText.gameObject.SetActive(!b))
                .OnChangedAndInit(b => DiscardText.text = LanguageManager.Instance.GetTextValue("CardDiscardText"));
        }
    }
}