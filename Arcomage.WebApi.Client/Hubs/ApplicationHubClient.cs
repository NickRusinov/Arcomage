using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using static System.Threading.Tasks.TaskContinuationOptions;

namespace Arcomage.WebApi.Client.Hubs
{
    /// <summary>
    /// Базовый класс для реализации клиентов хабов SignalR
    /// </summary>
    public abstract class ApplicationHubClient : IDisposable
    {
        /// <summary>
        /// Хранит список подключенных событий хаба
        /// </summary>
        private readonly ConcurrentDictionary<Delegate, IDisposable> hubSubscriptions = 
            new ConcurrentDictionary<Delegate, IDisposable>();
        
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
        /// Таймер, поддерживающий постоянное соединение с серверным хабом
        /// </summary>
        private Timer hubTimer;

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="ApplicationHubClient"/>
        /// </summary>
        /// <param name="hubConnectionFactory">Фабрика для создания подключению к хабу</param>
        /// <param name="hubName">Имя хаба для подключения</param>
        protected ApplicationHubClient(IHubConnectionFactory hubConnectionFactory, string hubName)
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
        /// Таймер, поддерживающий постоянное соединение с серверным хабом
        /// </summary>
        protected Timer HubTimer => hubTimer = hubTimer ?? new Timer(x => HubConnection.Start());

        /// <summary>
        /// Устанавливает соединение с серверным хабом
        /// </summary>
        /// <returns>Операция соединения с серверным хабом</returns>
        public virtual Task Start()
        {
            return HubConnection.Start().ContinueWith(t => HubTimer.Change(5000, 5000), ExecuteSynchronously);
        }

        /// <summary>
        /// Завершает соединение с серверным хабом
        /// </summary>
        public virtual void Stop()
        {
            hubTimer?.Dispose();
            hubTimer = null;

            hubConnection?.Stop();
            hubConnection = null;
        }

        /// <summary>
        /// Вызывает метод серверного хаба
        /// </summary>
        /// <param name="name">Имя метода серверного хаба</param>
        /// <param name="args">Параметры метода серверного хаба</param>
        /// <returns>Операция вызова метода серверного хаба</returns>
        protected virtual Task Invoke(string name, params object[] args)
        {
            return Start().ContinueWith(t => HubProxy.Invoke(name, args), ExecuteSynchronously);
        }

        /// <summary>
        /// Добавление подписки на событие в отслеживаемый список подписок
        /// </summary>
        /// <param name="delegate">Добавленное событие хаба</param>
        /// <param name="subscription">Подписка на добавленное событие хаба</param>
        protected virtual void AddSubscription(Delegate @delegate, IDisposable subscription)
        {
            hubSubscriptions.TryAdd(@delegate, subscription);
        }

        /// <summary>
        /// Удаление подписки на событие из отслеживаемого списка подписок
        /// </summary>
        /// <param name="delegate">Удаленное событие хаба</param>
        protected virtual void RemoveSubscription(Delegate @delegate)
        {
            if (hubSubscriptions.TryRemove(@delegate, out var subscription))
                subscription.Dispose();
        }
        
        /// <summary>
        /// Завершает соединение с серверным хабом
        /// </summary>
        public virtual void Dispose()
        {
            Stop();
        }
    }
}
