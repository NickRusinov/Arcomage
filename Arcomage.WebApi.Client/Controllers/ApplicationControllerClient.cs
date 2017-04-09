using System;
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
    public abstract class ApplicationControllerClient
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
        /// Инициализирует экземпляр класса <see cref="ApplicationControllerClient"/>
        /// </summary>
        /// <param name="httpClientFactory">Фабрика для создания http клиентов</param>
        protected ApplicationControllerClient(IHttpClientFactory httpClientFactory)
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
        /// <param name="url">Относительный путь запроса</param>
        /// <returns>Задача, представляющая вызов метода</returns>
        protected virtual async Task Get(string url)
        {
            await HttpClient.Get(url);
        }

        /// <summary>
        /// Вызов get метода контроллера
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого значения метода</typeparam>
        /// <param name="url">Относительный путь запроса</param>
        /// <returns>Задача, представляющая вызов метода</returns>
        protected virtual async Task<T> Get<T>(string url)
        {
            var response = await HttpClient.Get(url);

            return JsonConvert.DeserializeObject<T>(response);
        }

        /// <summary>
        /// Вызов post метода контроллера
        /// </summary>
        /// <param name="url">Относительный путь запроса</param>
        /// <param name="data">Данные, отправляемые в запросе</param>
        /// <returns>Задача, представляющая вызов метода</returns>
        protected virtual async Task Post(string url, IDictionary<string, string> data = null)
        {
            await httpClient.Post(url, data ?? new Dictionary<string, string>(0));
        }

        /// <summary>
        /// Вызов post метода контроллера
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого значения метода</typeparam>
        /// <param name="url">Относительный путь запроса</param>
        /// <param name="data">Данные, отправляемые в запросе</param>
        /// <returns>Задача, представляющая вызов метода</returns>
        protected virtual async Task<T> Post<T>(string url, IDictionary<string, string> data = null)
        {
            var response = await HttpClient.Post(url, data ?? new Dictionary<string, string>(0));

            return JsonConvert.DeserializeObject<T>(response);
        }
    }
}
