using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
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
            cardObject.GetComponent<HistoryCardScript>().Index = index;
            cardObject.name = "Card" + index;

            cardObject.GetComponent<HistoryCardScript>().Initialize(card);

            return cardObject;
        }
    }
}
