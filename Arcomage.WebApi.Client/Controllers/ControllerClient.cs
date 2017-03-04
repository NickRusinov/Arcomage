using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Arcomage.WebApi.Client.Controllers
{
    public abstract class ControllerClient
    {
        private readonly IHttpClient httpClient;

        protected ControllerClient(IHttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        
        protected virtual Task<T> Get<T>(string url)
        {
            return httpClient.Get(url)
                .ContinueWith(t => JsonConvert.DeserializeObject<T>(t.Result));
        }

        protected virtual Task<T> Post<T>(string url, IDictionary<string, string> data)
        {
            return httpClient.Post(url, data)
                .ContinueWith(t => JsonConvert.DeserializeObject<T>(t.Result));
        }
    }
}
