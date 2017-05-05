using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Unity.GameScene.ViewModels;
using Arcomage.Unity.Shared.Scripts;
using SmartLocalization;
using UnityEngine;
using UnityEngine.UI;

namespace Arcomage.Unity.GameScene.Views
{
    /// <summary>
    /// Представление компонента игровой карты
    /// </summary>
    public class CardView : View<CardViewModel>
    {
        [Tooltip("Текст для вывода названия карты")]
        public Text NameText;

        [Tooltip("Текст для вывода описания карты")]
        public Text DescriptionText;

        [Tooltip("Текст для вывода стоимости карты")]
        public Text PriceText;

        [Tooltip("Спрайт фона карты")]
        public Image BackgroundImage;

        [Tooltip("Спрайт изображения карты")]
        public Image ForegroundImage;

        [Tooltip("Материал для фона карты, когда она может быть разыграна")]
        public Material BackgroundCanPlayMaterial;

        [Tooltip("Материал для фона карты, когда она не может быть разыграна")]
        public Material BackgroundCannotPlayMaterial;

        protected override void OnViewModel(CardViewModel viewModel)
        {
            Bind(viewModel.Identifier)
                .OnInit(i => ForegroundImage.sprite = Resources.Load<Sprite>("Card" + i + "Image"))
                .OnInit(i => NameText.text = LanguageManager.Instance.GetTextValue("Card" + i + "Name"))
                .OnInit(i => DescriptionText.text = LanguageManager.Instance.GetTextValue("Card" + i + "Description"));

            Bind(viewModel, c => c.Kind)
                .OnChangedAndInit(r => BackgroundImage.sprite = Resources.Load<Sprite>("Card" + r + "Image"));

            Bind(viewModel, c => c.Price)
                .OnChangedAndInit(p => PriceText.text = p.ToString());

            Bind(viewModel, c => c.IsPlay)
                .OnChangedAndInit(can => can, can => BackgroundImage.material = BackgroundCanPlayMaterial)
                .OnChangedAndInit(can => !can, can => BackgroundImage.material = BackgroundCannotPlayMaterial);
        }
    }
}