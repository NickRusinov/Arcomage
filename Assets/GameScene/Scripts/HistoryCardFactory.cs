using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain.Histories;
using Arcomage.Unity.GameScene.Views;
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
        /// <param name="transform">Положение карты в истории хода</param>
        /// <param name="card">Карта в истории хода</param>
        /// <param name="index">Номер карты в истории хода</param>
        /// <returns>Игровой объект карты в истории хода</returns>
        public GameObject CreateCard(Transform transform, HistoryCard card, int index)
        {
            var cardObject = (GameObject)Instantiate(Prefab, transform);
            cardObject.GetComponent<HistoryCardView>().Index = index;
            cardObject.name = "Card" + index;

            cardObject.GetComponent<HistoryCardView>().Initialize(card);

            return cardObject;
        }
    }
}
