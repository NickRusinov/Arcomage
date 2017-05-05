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
    /// Фабрика, создающая игровые объекты карты из префаба
    /// </summary>
    public class CardFactory : MonoBehaviour
    {
        [Tooltip("Префаб карты")]
        public GameObject Prefab;

        /// <summary>
        /// Создает игровой объект карты
        /// </summary>
        /// <param name="template">Шаблон положения карты</param>
        /// <param name="cardViewModel">Модель представления игровой карты</param>
        /// <returns>Игровой объект карты</returns>
        public GameObject CreateCard(GameObject template, CardViewModel cardViewModel)
        {
            var templateTransform = template.GetComponent<RectTransform>();

            var cardObject = (GameObject)Instantiate(Prefab, templateTransform.parent);
            cardObject.name = "Card" + cardViewModel.Index;

            var cardTransform = cardObject.GetComponent<RectTransform>();
            cardTransform.CopyFrom(templateTransform);

            var cardView = cardObject.GetComponent<CardView>();
            cardView.ViewModel = cardViewModel;
            
            cardObject.GetComponent<CardDragDropScript>();

            return cardObject;
        }
    }
}
