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

            var webRequest = UnityWebRequest.Post(baseUrl + url, dictionaryData);

            return Send(webRequest);
        }

        private Task<string> Send(UnityWebRequest webRequest)
        {
            foreach (var pair in Headers)
                webRequest.SetRequestHeader(pair.Key, pair.Value);

            var task = sendWebRequest.Invoke(webRequest);
            task.ContinueWith(t => Trace(t.Result), TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t => Trace(t.Exception.ToString()), TaskContinuationOptions.OnlyOnFaulted);

            return task;
        }

        private void Trace(string message)
        {
            if (TraceWriter != null)
                TraceWriter.Write(message);
        }
    }
}
