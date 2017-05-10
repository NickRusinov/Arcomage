using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.WebApi.Client;
using UnityEngine;
using UnityEngine.Networking;

namespace Arcomage.Unity.Framework.Scripts
{
    public class UnityHttpClientFactory : MonoBehaviour, IHttpClientFactory
    {
        [Tooltip("Адрес веб-сервера игры")]
        public string BaseUrl;

        public IHttpClient Open()
        {
            var httpClient = new UnityHttpClient(new Uri(BaseUrl), SendWebRequest);
            httpClient.TraceWriter = new UnityLogTextWriter();
            httpClient.Headers.Add(Global.Authorization.GetAuthorizationHeader(), Global.Authorization.GetAuthorizationToken());
            httpClient.Headers.Add("Content-Type", "application/json");

            return httpClient;
        }

        public void Close(IHttpClient httpClient)
        {
            throw new NotImplementedException();
        }

        private Task<string> SendWebRequest(UnityWebRequest webRequest)
        {
            var taskCompletionSource = new TaskCompletionSource<string>();
            StartCoroutine(SendWebRequestCoroutine(taskCompletionSource, webRequest));

            return taskCompletionSource.Task;
        }

        private IEnumerator SendWebRequestCoroutine(TaskCompletionSource<string> taskCompletionSource, UnityWebRequest webRequest)
        {
            yield return webRequest.Send();

            if (webRequest.isError)
                taskCompletionSource.SetException(new Exception(webRequest.error));

            else
                taskCompletionSource.SetResult(webRequest.downloadHandler.text);
        }
    }
}
