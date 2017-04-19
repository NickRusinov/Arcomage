using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.WebApi.Client.Models.Game;
using Microsoft.AspNet.SignalR.Client;

namespace Arcomage.WebApi.Client.Hubs
{
    /// <summary>
    /// Клиент хаба сетевой игры
    /// </summary>
    public class PlayGameHubClient : ApplicationHubClient
    {
        /// <summary>
        /// Инициализирует экземпляр класса <see cref="PlayGameHubClient"/>
        /// </summary>
        /// <param name="hubConnectionFactory">Фабрика для создания подключению к хабу</param>
        public PlayGameHubClient(IHubConnectionFactory hubConnectionFactory) 
            : base(hubConnectionFactory, "PlayGameHub")
        {

        }

        /// <summary>
        /// Вызов серверного метода "Сыграть карту"
        /// </summary>
        /// <param name="cardIndex">Номер сыгранной карты</param>
        /// <returns>Задача, представляющая вызов серверного метода</returns>
        public Task PlayCard(int cardIndex)
        {
            return Invoke("PlayCard", cardIndex);
        }

        /// <summary>
        /// Вызов серверного метода "Сбросить карту"
        /// </summary>
        /// <param name="cardIndex">Номер сбрасываемой карты</param>
        /// <returns>Задача, представляющая вызов серверного метода</returns>
        public Task DiscardCard(int cardIndex)
        {
            return Invoke("DiscardCard", cardIndex);
        }

        /// <summary>
        /// Серверное событие хаба "Состояние игры изменено"
        /// </summary>
        public event Action<GameModel> OnUpdate
        {
            add { AddSubscription(value, HubProxy.On("Update", value)); }
            remove { RemoveSubscription(value); }
        }
    }
}
