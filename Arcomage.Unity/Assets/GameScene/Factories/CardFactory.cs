using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Unity.GameScene.Scripts;
using Arcomage.Unity.GameScene.ViewModels;
using Arcomage.Unity.GameScene.Views;
using UnityEngine;

namespace Arcomage.Unity.GameScene.Factories
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
        /// <param name="transform">Положение карты</param>
        /// <param name="cardViewModel">Модель представления игровой карты</param>
        /// <returns>Игровой объект карты</returns>
        public GameObject CreateCard(Transform transform, CardViewModel cardViewModel)
        {
            var cardObject = (GameObject)Instantiate(Prefab, transform);
            cardObject.name = "Card" + cardViewModel.Index;

            cardObject.GetComponent<CardView>().ViewModel = cardViewModel;
            cardObject.GetComponent<CardDragDropScript>();

            return cardObject;
        }
    }
}
