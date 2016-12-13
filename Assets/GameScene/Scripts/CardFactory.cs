using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Unity.GameScene.Views;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class CardFactory : MonoBehaviour
    {
        [Tooltip("Префаб карты")]
        public GameObject Prefab;

        private Command playCommand;

        private Command discardCommand;

        public void Initialize(Command playCommand, Command discardCommand)
        {
            this.playCommand = playCommand;
            this.discardCommand = discardCommand;
        }

        public GameObject CreateCard(Transform transform, Card card, int index)
        {
            var cardObject = (GameObject)Instantiate(Prefab, transform);
            cardObject.GetComponent<CardView>().Index = index;
            cardObject.name = "Card" + index;

            cardObject.GetComponent<CardView>().Initialize(card, playCommand);
            cardObject.GetComponent<CardDragDropScript>().Initialize(playCommand, discardCommand);

            return cardObject;
        }
    }
}
