using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using NLog;

namespace Arcomage.WebApi.Infrastructure
{
    /// <summary>
    /// Выполняет логирование всех запросов, выполняемых через <see cref="IMediator"/>
    /// </summary>
    /// <typeparam name="TRequest">Тип запроса</typeparam>
    /// <typeparam name="TResponse">Тип ответа</typeparam>
    public class NLogPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        /// <summary>
        /// Логгер
        /// </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Выполяняет логирование отправленного запроса
        /// </summary>
        /// <param name="request">Объект запроса</param>
        /// <param name="next">Обработчик запроса</param>
        /// <returns>Объект ответа</returns>
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                logger.Debug("Начало выполнения обработки запроса {0}", request);
                var response = await next.Invoke();
                logger.Debug("Завершение выполнения обработки запроса {0} с результатом {1}", request, response);

                return response;
            }
            catch (Exception e)
            {
                logger.Warn(e, "Исключение во время обработки запроса {0}", request);
                throw;
            }
        }
    }
}
