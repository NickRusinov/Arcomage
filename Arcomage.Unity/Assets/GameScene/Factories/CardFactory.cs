using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain;
using Arcomage.Domain.Cards;
using Arcomage.Domain.Players;
using Arcomage.Domain.Services;
using Arcomage.Unity.GameScene.Commands;
using Arcomage.Unity.GameScene.Scripts;
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

        private Game game;

        private HumanPlayer player;

        private IPlayCardCriteria playCardCriteria;

        private IDiscardCardCriteria discardCardCriteria;

        /// <summary>
        /// Инициализация фабрики
        /// </summary>
        public void Initialize(Game game, HumanPlayer player, IPlayCardCriteria playCardCriteria, IDiscardCardCriteria discardCardCriteria)
        {
            this.game = game;
            this.player = player;
            this.playCardCriteria = playCardCriteria;
            this.discardCardCriteria = discardCardCriteria;
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

            cardObject.GetComponent<CardView>().Initialize(card);
            cardObject.GetComponent<CardDragDropScript>();
            cardObject.GetComponent<PlayCardCommand>().Initialize(game, player, playCardCriteria);
            cardObject.GetComponent<DiscardCardCommand>().Initialize(game, player, discardCardCriteria);

            return cardObject;
        }
    }
}
