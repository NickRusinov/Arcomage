using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Unity.GameScene.ViewModels;
using Arcomage.Unity.GameScene.Views;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;

namespace Arcomage.Unity.GameScene.Scripts
{
    /// <summary>
    /// Фабрика, создающая игровые объекты карт в истории хода
    /// </summary>
    public class HistoryCardFactory : MonoBehaviour
    {
        [Tooltip("Префаб карты")]
        public GameObject Prefab;

        /// <summary>
        /// Создает игровой объект карты в истории хода
        /// </summary>
        /// <param name="template">Шаблон положения карты в истории хода</param>
        /// <param name="cardViewModel">Модель представления карты в истории хода</param>
        /// <returns>Игровой объект карты в истории хода</returns>
        public GameObject CreateCard(GameObject template, HistoryCardViewModel cardViewModel)
        {
            var templateTransform = template.GetComponent<RectTransform>();

            var cardObject = (GameObject)Instantiate(Prefab, templateTransform.parent);
            cardObject.name = "Card" + cardViewModel.Index;

            var cardTransform = cardObject.GetComponent<RectTransform>();
            cardTransform.CopyFrom(templateTransform);

            var inCardObjectTransform = (RectTransform)cardObject.transform.GetChild(0);
            inCardObjectTransform.pivot = templateTransform.pivot;

            var cardView = cardObject.GetComponent<HistoryCardView>();
            cardView.ViewModel = cardViewModel;

            return cardObject;
        }
    }
}
