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
        /// <param name="index">Номер карты в руке игрока</param>
        /// <returns>Игровой объект карты</returns>
        public GameObject CreateCard(Transform transform, CardViewModel cardViewModel, int index)
        {
            var cardObject = (GameObject)Instantiate(Prefab, transform);
            cardObject.GetComponent<CardView>().Index = index;
            cardObject.name = "Card" + index;

            cardObject.GetComponent<CardView>().Initialize(cardViewModel);
            cardObject.GetComponent<CardDragDropScript>();

            return cardObject;
        }
    }
}
