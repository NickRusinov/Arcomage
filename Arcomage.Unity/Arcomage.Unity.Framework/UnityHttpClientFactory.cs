using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Unity.Framework.Services;
using Arcomage.WebApi.Client;

namespace Arcomage.Unity.Framework
{
    public class UnityHttpClientFactory : IHttpClientFactory
    {
        private readonly string baseUrl;
        
        private readonly Authorization authorization;

        private readonly Scene scene;

        public UnityHttpClientFactory(string baseUrl, Authorization authorization, Scene scene)
        {
            this.baseUrl = baseUrl;
            this.authorization = authorization;
            this.scene = scene;
        }

        public IHttpClient Open()
        {
            var authorizationHeader = authorization.GetAuthorizationHeader();
            var authorizationToken = authorization.GetAuthorizationToken();

            var httpClient = new UnityHttpClient(new Uri(baseUrl), scene);
            httpClient.TraceWriter = new UnityLogTextWriter();
            httpClient.Headers.Add(authorizationHeader, authorizationToken);
            httpClient.Headers.Add("Content-Type", "application/json");

            return httpClient;
        }

        public void Close(IHttpClient httpClient)
        {
            throw new NotImplementedException();
        }
    }
}
