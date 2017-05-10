using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.WebApi.Client;
using UnityEngine;
using UnityEngine.Networking;

namespace Arcomage.Unity.Framework
{
    /// <summary>
    /// Реализация http клиента на основе <see cref="UnityWebRequest"/>
    /// </summary>
    public class UnityHttpClient : IHttpClient
    {
        /// <summary>
        /// Корневой адрес игрового сервера
        /// </summary>
        private readonly Uri baseUrl;

        /// <summary>
        /// Объект Unity, который выполняет сопрограмму для ожидания результатов http запросов, отправленных через 
        /// <see cref="UnityWebRequest"/>
        /// </summary>
        private readonly MonoBehaviour monoBehaviour;

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="UnityHttpClient"/>
        /// </summary>
        /// <param name="baseUrl">Корневой адрес игрового сервера</param>
        /// <param name="monoBehaviour">
        /// Объект Unity, который выполняет сопрограмму для ожидания результатов http запросов, отправленных через 
        /// <see cref="UnityWebRequest"/>
        /// </param>
        public UnityHttpClient(Uri baseUrl, MonoBehaviour monoBehaviour)
        {
            this.baseUrl = baseUrl;
            this.monoBehaviour = monoBehaviour;
        }

        /// <summary>
        /// Заголовки запроса, отправляемые на игровой сервер
        /// </summary>
        public IDictionary<string, string> Headers { get; } = new Dictionary<string, string>();

        /// <summary>
        /// Поток, выполяняющий запись логов данных, отправляемых и принимаемых по сети
        /// </summary>
        public TextWriter TraceWriter { get; set; }

        /// <inheritdoc />
        public Task<string> Get(string url)
        {
            var uri = new Uri(baseUrl, url);
            var webRequest = UnityWebRequest.Get(uri.ToString());

            return Send(webRequest);
        }

        /// <inheritdoc />
        public Task<string> Post(string url, IDictionary<string, string> data)
        {
            var dictionaryData = data as Dictionary<string, string> ?? new Dictionary<string, string>(data);

            // BUG https://issuetracker.unity3d.com/issues/unitywebrequest-post-with-empty-body-results-in-error
            if (dictionaryData.Count == 0)
                dictionaryData.Add(Guid.NewGuid().ToString("N"), Guid.NewGuid().ToString("N"));

            var uri = new Uri(baseUrl, url);
            var webRequest = UnityWebRequest.Post(uri.ToString(), dictionaryData);

            return Send(webRequest);
        }

        /// <summary>
        /// Отправляет запрос на игровой сервер и возвращает задачу, представляющую ожидание ответа от сервера
        /// </summary>
        /// <param name="webRequest">Объект запроса на игровой сервер</param>
        /// <returns>Задача, предтавляющая ожидание ответа от сервера</returns>
        private Task<string> Send(UnityWebRequest webRequest)
        {
            var taskCompletionSource = new TaskCompletionSource<string>();
            monoBehaviour.StartCoroutine(SendWebRequestCoroutine(webRequest, taskCompletionSource));

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Сопрограмма, отправляющая запрос на игровой сервер и ожидающая ответа от сервера
        /// </summary>
        /// <param name="webRequest">Объект запроса на игровой сервер</param>
        /// <param name="taskCompletionSource">Задача, завершающаяся при получении ответа от сервера</param>
        /// <returns>Сопрограмма</returns>
        private IEnumerator SendWebRequestCoroutine(UnityWebRequest webRequest, TaskCompletionSource<string> taskCompletionSource)
        {
            foreach (var pair in Headers)
                webRequest.SetRequestHeader(pair.Key, pair.Value);

            yield return webRequest.Send();

            if (webRequest.isError)
            {
                TraceWriter?.Write(webRequest.error);
                taskCompletionSource.SetException(new Exception(webRequest.error));
            }
            else
            {
                TraceWriter?.Write(webRequest.downloadHandler.text);
                taskCompletionSource.SetResult(webRequest.downloadHandler.text);
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {

        }
    }
}
