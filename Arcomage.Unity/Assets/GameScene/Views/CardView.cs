using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Unity.GameScene.Commands;
using Arcomage.Unity.GameScene.Scripts;
using Arcomage.Unity.GameScene.ViewModels;
using Arcomage.Unity.Shared.Scripts;
using SmartLocalization;
using UnityEngine;

namespace Arcomage.Unity.GameScene.Views
{
    /// <summary>
    /// Представление компонента игровой карты
    /// </summary>
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

        /// <summary>
        /// Инициализация компонента
        /// </summary>
        /// <param name="cardViewModel">Модель представления игровой карты</param>
        public void Initialize(CardViewModel cardViewModel)
        {
            Bind(cardViewModel.Identifier)
                .OnInit(i => ForegroundImage.sprite = Resources.Load<Sprite>("Card" + i + "Image"))
                .OnInit(i => NameText.text = LanguageManager.Instance.GetTextValue("Card" + i + "Name"))
                .OnInit(i => DescriptionText.text = LanguageManager.Instance.GetTextValue("Card" + i + "Description"));

            Bind(cardViewModel, c => c.Kind)
                .OnChangedAndInit(r => BackgroundImage.sprite = Resources.Load<Sprite>("Card" + r + "Image"));

            Bind(cardViewModel, c => c.Price)
                .OnChangedAndInit(p => PriceText.text = p.ToString());

            Bind(new PlayCardCommand { Index = Index }, c => GameSceneScript.Dispatcher.CanExecute(c))
                .OnChangedAndInit(can => can, can => BackgroundImage.material = BackgroundCanPlayMaterial)
                .OnChangedAndInit(can => !can, can => BackgroundImage.material = BackgroundCannotPlayMaterial);
        }
    }
}