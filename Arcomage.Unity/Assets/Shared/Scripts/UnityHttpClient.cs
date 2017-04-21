using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.WebApi.Client;
using UnityEngine.Networking;

namespace Arcomage.Unity.Shared.Scripts
{
    public class UnityHttpClient : IHttpClient
    {
        private readonly string baseUrl;

        private readonly Func<UnityWebRequest, Task<string>> sendWebRequest;

        public UnityHttpClient(string baseUrl, Func<UnityWebRequest, Task<string>> sendWebRequest)
        {
            this.baseUrl = baseUrl;
            this.sendWebRequest = sendWebRequest;
            this.Headers = new Dictionary<string, string>();
        }

        public IDictionary<string, string> Headers { get; private set; }

        public TextWriter TraceWriter { get; set; }

        public Task<string> Get(string url)
        {
            var webRequest = UnityWebRequest.Get(baseUrl + url);

            return Send(webRequest);
        }

        public Task<string> Post(string url, IDictionary<string, string> data)
        {
            var dictionaryData = data as Dictionary<string, string> ?? new Dictionary<string, string>(data);

            // BUG https://issuetracker.unity3d.com/issues/unitywebrequest-post-with-empty-body-results-in-error
            if (dictionaryData.Count == 0)
                dictionaryData.Add(Guid.NewGuid().ToString("N"), Guid.NewGuid().ToString("N"));

            var webRequest = UnityWebRequest.Post(baseUrl + url, dictionaryData);

            return Send(webRequest);
        }

        private Task<string> Send(UnityWebRequest webRequest)
        {
            foreach (var pair in Headers)
                webRequest.SetRequestHeader(pair.Key, pair.Value);

            var task = sendWebRequest.Invoke(webRequest);
            task.ContinueWith(t => Trace(t.Result), TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.ExecuteSynchronously);
            task.ContinueWith(t => Trace(t.Exception.ToString()), TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously);

            return task;
        }

        private void Trace(string message)
        {
            if (TraceWriter != null)
                TraceWriter.Write(message);
        }

        public void Dispose()
        {

        }
    }
}
