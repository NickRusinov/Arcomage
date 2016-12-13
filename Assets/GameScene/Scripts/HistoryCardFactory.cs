using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Unity.GameScene.Views;
using UnityEngine;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class HistoryCardFactory : MonoBehaviour
    {
        [Tooltip("Префаб карты")]
        public GameObject Prefab;

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
