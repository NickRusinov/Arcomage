using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace Arcomage.WebApi.Client.Hubs
{
    /// <summary>
    /// Базовый класс для реализации клиентов хабов SignalR
    /// </summary>
    public abstract class HubClient
    {
        /// <summary>
        /// Хранит список подключенных событий хаба
        /// </summary>
        private readonly Dictionary<Delegate, IDisposable> hubSubscriptions = new Dictionary<Delegate, IDisposable>();
        
        /// <summary>
        /// Фабрика для создания подключению к хабу
        /// </summary>
        private readonly IHubConnectionFactory hubConnectionFactory;

        /// <summary>
        /// Имя хаба для подключения
        /// </summary>
        private readonly string hubName;

        /// <summary>
        /// Подключение к хабу
        /// </summary>
        private HubConnection hubConnection;

        /// <summary>
        /// Прокси серверного хаба
        /// </summary>
        private IHubProxy hubProxy;

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="HubClient"/>
        /// </summary>
        /// <param name="hubConnectionFactory">Фабрика для создания подключению к хабу</param>
        /// <param name="hubName">Имя хаба для подключения</param>
        protected HubClient(IHubConnectionFactory hubConnectionFactory, string hubName)
        {
            this.hubConnectionFactory = hubConnectionFactory;
            this.hubName = hubName;
        }

        /// <summary>
        /// Подключение к хабу
        /// </summary>
        protected HubConnection HubConnection => hubConnection = hubConnection ?? hubConnectionFactory.Open();

        /// <summary>
        /// Прокси серверного хаба
        /// </summary>
        protected IHubProxy HubProxy => hubProxy = hubProxy ?? HubConnection.CreateHubProxy(hubName);
        
        /// <summary>
        /// Устанавливает соединение с серверным хабом
        /// </summary>
        /// <returns>Операция соединения с серверным хабом</returns>
        public virtual Task Start()
        {
            return HubConnection.Start();
        }

        /// <summary>
        /// Завершает соединение с серверным хабом
        /// </summary>
        public virtual void Stop()
        {
            hubConnection?.Stop();
        }

        /// <summary>
        /// Добавление подписки на событие в отслеживаемый список подписок
        /// </summary>
        /// <param name="delegate">Добавленное событие хаба</param>
        /// <param name="subscription">Подписка на добавленное событие хаба</param>
        protected virtual void AddSubscription(Delegate @delegate, IDisposable subscription)
        {
            hubSubscriptions.Add(@delegate, subscription);
        }

        /// <summary>
        /// Удаление подписки на событие из отслеживаемого списка подписок
        /// </summary>
        /// <param name="delegate">Удаленное событие хаба</param>
        protected virtual void RemoveSubscription(Delegate @delegate)
        {
            if (hubSubscriptions.TryGetValue(@delegate, out var subscription))
            {
                hubSubscriptions.Remove(@delegate);
                subscription.Dispose();
            }
        }
    }
}
