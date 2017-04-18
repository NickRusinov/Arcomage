using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.WebApi.Client
{
    /// <summary>
    /// Представляет http клиент, выполняющий запросы к серверу
    /// </summary>
    public interface IHttpClient : IDisposable
    {
        /// <summary>
        /// Вызывает get метод
        /// </summary>
        /// <param name="url">Путь выполняемого метода</param>
        /// <returns>Задача, представляющая вызов метода</returns>
        Task<string> Get(string url);

        /// <summary>
        /// Вызов post метода
        /// </summary>
        /// <param name="url">Путь выполняемого метода</param>
        /// <param name="data">Данные, отправляемые в запросе</param>
        /// <returns>Задача, представляющая вызов метода</returns>
        Task<string> Post(string url, IDictionary<string, string> data);
    }
}
