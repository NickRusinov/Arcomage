using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Unity.GameScene.ViewModels;
using Arcomage.Unity.GameScene.Views;
using UnityEngine;

namespace Arcomage.Unity.GameScene.Factories
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
        /// <param name="transform">Положение карты в истории хода</param>
        /// <param name="cardViewModel">Модель представления карты в истории хода</param>
        /// <returns>Игровой объект карты в истории хода</returns>
        public GameObject CreateCard(Transform transform, HistoryCardViewModel cardViewModel)
        {
            var cardObject = (GameObject)Instantiate(Prefab, transform);
            cardObject.name = "Card" + cardViewModel.Index;

            cardObject.GetComponent<HistoryCardView>().ViewModel = cardViewModel;

            return cardObject;
        }
    }
}
