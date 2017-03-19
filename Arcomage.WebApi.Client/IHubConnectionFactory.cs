using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNet.SignalR.Client;

namespace Arcomage.WebApi.Client
{
    /// <summary>
    /// Фабрика для создания подключению к хабу
    /// </summary>
    public interface IHubConnectionFactory
    {
        /// <summary>
        /// Создает подключение к хабу
        /// </summary>
        /// <returns>Подключение к хабу</returns>
        HubConnection Open();

        /// <summary>
        /// Освобождает подключение к хабу
        /// </summary>
        /// <param name="connection">Подключение к хабу</param>
        void Close(HubConnection connection);
    }
}
