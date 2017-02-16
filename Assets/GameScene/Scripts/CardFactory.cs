using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
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
        /// Команда, вызываемая при активации карты игроком
        /// </summary>
        private Command playCommand;

        /// <summary>
        /// Команда, вызываемая при сбросе карты игроком
        /// </summary>
        private Command discardCommand;

        /// <summary>
        /// Инициализация фабрики
        /// </summary>
        /// <param name="playCommand">Команда, вызываемая при активации карты игроком</param>
        /// <param name="discardCommand">Команда, вызываемая при сбросе карты игроком</param>
        public void Initialize(Command playCommand, Command discardCommand)
        {
            this.playCommand = playCommand;
            this.discardCommand = discardCommand;
        }

        /// <summary>
        /// Создает игровой объект карты
        /// </summary>
        /// <param name="transform">Положение карты</param>
        /// <param name="card">Игровая карта</param>
        /// <param name="index">Номер карты в руке игрока</param>
        /// <returns>Игровой объект карты</returns>
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
