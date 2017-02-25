using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Arcomage.WebApi.Client.Controllers
{
    public abstract class ControllerClient
    {
        private readonly string baseUrl;

        private readonly string authenticate;

        protected ControllerClient(string baseUrl, string authenticate)
        {
            this.baseUrl = baseUrl;
            this.authenticate = authenticate;
        }

        protected virtual WebClient CreateClient()
        {
            var webClient = new WebClient();
            webClient.Headers.Add("Authenticate", authenticate);
            webClient.Headers.Add("Content-Type", "application/json");
            webClient.Encoding = Encoding.UTF8;
            webClient.BaseAddress = baseUrl;

            return webClient;
        }

        protected virtual Task<T> Get<T>(string url)
        {
            var webClient = CreateClient();
            var taskSource = new TaskCompletionSource<T>(webClient);

            webClient.DownloadStringCompleted += (sender, args) => AsyncCompleted(taskSource, args, args.Result);
            webClient.DownloadStringAsync(new Uri(webClient.BaseAddress + url));

            return taskSource.Task;
        }

        protected virtual void AsyncCompleted<T>(TaskCompletionSource<T> taskSource, AsyncCompletedEventArgs args, string result)
        {
            if (args.Error != null)
            {
                taskSource.SetException(args.Error);
            }
            else if (args.Cancelled)
            {
                taskSource.SetCanceled();
            }
            else if (result != null)
            {
                try
                {
                    taskSource.SetResult(JsonConvert.DeserializeObject<T>(result));
                }
                catch (JsonException e)
                {
                    taskSource.SetException(e);
                }
            }
        }
    }
}
