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
    public class CardView : View
    {
        [Tooltip("Текст для вывода названия карты")]
        public TextMesh NameText;

        [Tooltip("Текст для вывода описания карты")]
        public TextMesh DescriptionText;

        [Tooltip("Текст для вывода стоимости карты")]
        public TextMesh PriceText;

        [Tooltip("Спрайт фона карты")]
        public SpriteRenderer BackgroundImage;

        [Tooltip("Спрайт изображения карты")]
        public SpriteRenderer ForegroundImage;

        [Tooltip("Материал для фона карты, когда она может быть разыграна")]
        public Material BackgroundCanPlayMaterial;

        [Tooltip("Материал для фона карты, когда она не может быть разыграна")]
        public Material BackgroundCannotPlayMaterial;

        [NonSerialized]
        public int Index;

        public void Initialize(Card card, Command playCommand)
        {
            card.Identifier = card.GetIdentifier();

            Bind(card, c => c.Identifier)
                .OnChangedAndInit(i => ForegroundImage.sprite = UnityEngine.Resources.Load<Sprite>("Card" + i + "Image"))
                .OnChangedAndInit(i => NameText.text = LanguageManager.Instance.GetTextValue("Card" + i + "Name"))
                .OnChangedAndInit(i => DescriptionText.text = LanguageManager.Instance.GetTextValue("Card" + i + "Description"));

            Bind(card, c => c.GetResources())
                .OnChangedAndInit(r => BackgroundImage.sprite = UnityEngine.Resources.Load<Sprite>("Card" + r + "Image"));

            Bind(card, c => c.ResourcePrice)
                .OnChangedAndInit(p => PriceText.text = p.ToString());

            Bind(playCommand, c => c.CanExecute(Index))
                .OnChangedAndInit(can => can, can => BackgroundImage.material = BackgroundCanPlayMaterial)
                .OnChangedAndInit(can => !can, can => BackgroundImage.material = BackgroundCannotPlayMaterial);
        }
    }
}