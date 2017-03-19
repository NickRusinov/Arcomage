using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.WebApi.Client
{
    /// <summary>
    /// Фабрика для создания http клиентов
    /// </summary>
    public interface IHttpClientFactory
    {
        /// <summary>
        /// Создает http клиент
        /// </summary>
        /// <returns>Http клиент</returns>
        IHttpClient Open();

        /// <summary>
        /// Освобождает http клиент
        /// </summary>
        /// <param name="httpClient">Http клиент</param>
        void Close(IHttpClient httpClient);
    }
}
