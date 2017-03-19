﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Arcomage.WebApi.Client.Controllers
{
    /// <summary>
    /// Базовый класс для реализации клиентов контроллеров
    /// </summary>
    public abstract class ControllerClient
    {
        /// <summary>
        /// Фабрика для создания http клиентов
        /// </summary>
        private readonly IHttpClientFactory httpClientFactory;

        /// <summary>
        /// Http клиент
        /// </summary>
        private IHttpClient httpClient;

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="ControllerClient"/>
        /// </summary>
        /// <param name="httpClientFactory">Фабрика для создания http клиентов</param>
        protected ControllerClient(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Http клиент
        /// </summary>
        protected IHttpClient HttpClient => httpClient = httpClient ?? httpClientFactory.Open();
        
        /// <summary>
        /// Вызов get метода контроллера
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого значения метода</typeparam>
        /// <param name="url">Относительный путь запроса</param>
        /// <returns>Задача, представляющая вызов метода</returns>
        protected virtual Task<T> Get<T>(string url)
        {
            return HttpClient.Get(url)
                .ContinueWith(t => JsonConvert.DeserializeObject<T>(t.Result));
        }

        /// <summary>
        /// Вызов post метода контроллера
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого значения метода</typeparam>
        /// <param name="url">Относительный путь запроса</param>
        /// <param name="data">Данные, отправляемые в запросе</param>
        /// <returns>Задача, представляющая вызов метода</returns>
        protected virtual Task<T> Post<T>(string url, IDictionary<string, string> data)
        {
            return HttpClient.Post(url, data)
                .ContinueWith(t => JsonConvert.DeserializeObject<T>(t.Result));
        }
    }
}
