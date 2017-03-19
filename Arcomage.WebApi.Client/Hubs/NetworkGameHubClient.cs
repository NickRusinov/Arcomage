using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace Arcomage.WebApi.Client.Hubs
{
    /// <summary>
    /// Клиент хаба подключения к сетевой игре
    /// </summary>
    public class NetworkGameHubClient : HubClient
    {
        /// <summary>
        /// Инициализирует экземпляр класса <see cref="NetworkGameHubClient"/>
        /// </summary>
        /// <param name="hubConnectionFactory">Фабрика для создания подключению к хабу</param>
        public NetworkGameHubClient(IHubConnectionFactory hubConnectionFactory)
            : base(hubConnectionFactory, "NetworkGameHub")
        {
            
        }

        /// <summary>
        /// Вызов серверного метода "Подключиться к игре"
        /// </summary>
        /// <returns>Задача, представляющая вызов серверного метода</returns>
        public Task Connect()
        {
            return HubProxy.Invoke("Connect");
        }

        /// <summary>
        /// Серверное событие хаба "Подключение к игре произведено"
        /// </summary>
        public event Action<Guid> OnStartGame
        {
            add { AddSubscription(value, HubProxy.On("StartGame", value)); }
            remove { RemoveSubscription(value); }
        }
    }
}
