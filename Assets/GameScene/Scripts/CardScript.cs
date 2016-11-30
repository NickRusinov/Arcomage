using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class CardScript : View
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

        [NonSerialized]
        public int Index;

        public void Initialize(Card card, Command playCommand)
        {
            card.Identifier = card.GetIdentifier();

            Bind(card, c => c.Identifier)
                .OnChangedAndInit(i => ForegroundImage.sprite = UnityEngine.Resources.Load<Sprite>("Card" + i + "Image"))
                .OnChangedAndInit(i => NameText.text = Localization.ResourceManager.GetString("Card" + i + "Name"))
                .OnChangedAndInit(i => DescriptionText.text = Localization.ResourceManager.GetString("Card" + i + "Description"));

            Bind(card, c => c.GetResources())
                .OnChangedAndInit(r => BackgroundImage.sprite = UnityEngine.Resources.Load<Sprite>("Card" + r + "Image"));

            Bind(card, c => c.ResourcePrice)
                .OnChangedAndInit(p => PriceText.text = p.ToString());

            Bind(playCommand, c => c.CanExecute(Index))
                .OnChangedAndInit(can => can, can => BackgroundImage.color = new Color(1f, 1f, 1f))
                .OnChangedAndInit(can => !can, can => BackgroundImage.color = new Color(.5f, .5f, .5f, .5f));
        }
    }
}