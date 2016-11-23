using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class CardFactory
    {
        private readonly Command playCommand;

        private readonly Command discardCommand;

        public CardFactory(Command playCommand, Command discardCommand)
        {
            this.playCommand = playCommand;
            this.discardCommand = discardCommand;
        }

        public GameObject CreateCard(GameObject prefab, Transform transform, Card card, int index)
        {
            var cardObject = (GameObject)Object.Instantiate(prefab, transform);
            cardObject.name = "Card" + index;
            cardObject.tag = "Card";

            cardObject.GetComponent<CardScript>().Initialize(card);
            cardObject.GetComponent<CardDragDropScript>().Initialize(playCommand, discardCommand, index);

            return cardObject;
        }
    }
}
