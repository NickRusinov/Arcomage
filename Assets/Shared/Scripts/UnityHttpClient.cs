using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.WebApi.Client;
using UnityEngine;
using UnityEngine.Networking;

namespace Arcomage.Unity.Shared.Scripts
{
    public class UnityHttpClient : MonoBehaviour, IHttpClient
    {
        [Tooltip("Адрес веб-сервера игры")]
        public string BaseUrl;
        
        public Task<string> Get(string url)
        {
            var taskSource = new TaskCompletionSource<string>();
            var webRequest = UnityWebRequest.Get(BaseUrl + url);
            webRequest.SetRequestHeader("Authenticate", "authenticate");
            webRequest.SetRequestHeader("Content-Type", "application/json");

            StartCoroutine(ExecuteWebRequestCoroutine(taskSource, webRequest));

            return taskSource.Task;
        }

        public Task<string> Post(string url, IDictionary<string, string> data)
        {
            var dictionaryData = data as Dictionary<string, string> ?? new Dictionary<string, string>(data);
            var taskSource = new TaskCompletionSource<string>();
            var webRequest = UnityWebRequest.Post(BaseUrl + url, dictionaryData);
            webRequest.SetRequestHeader("Authenticate", "authenticate");
            webRequest.SetRequestHeader("Content-Type", "application/json");

            StartCoroutine(ExecuteWebRequestCoroutine(taskSource, webRequest));

            return taskSource.Task;
        }

        private static IEnumerator ExecuteWebRequestCoroutine(TaskCompletionSource<string> taskSource, UnityWebRequest webRequest)
        {
            yield return webRequest.Send();

            if (!webRequest.isError)
                taskSource.SetResult(webRequest.downloadHandler.text);
            else
                taskSource.SetException(new Exception(webRequest.error));
        }
    }
}
