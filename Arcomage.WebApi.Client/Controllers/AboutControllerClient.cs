using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.WebApi.Client.Models.About;

namespace Arcomage.WebApi.Client.Controllers
{
    /// <summary>
    /// Клиент контроллера, предоставляющего общую информацию о сервере
    /// </summary>
    public class AboutControllerClient : ControllerClient
    {
        /// <summary>
        /// Инициализирует экземпляр класса <see cref="AboutControllerClient"/>
        /// </summary>
        /// <param name="httpClientFactory">Фабрика для создания http клиентов</param>
        public AboutControllerClient(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {
            
        }

        /// <summary>
        /// Вызов метода "Получение версии сервера"
        /// </summary>
        /// <returns>Задача, представляющая вызов метода</returns>
        public Task<VersionModel> GetVersion()
        {
            return Get<VersionModel>("api/version");
        }
    }
}
