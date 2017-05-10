using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.WebApi.Client;
using UnityEngine;

namespace Arcomage.Unity.Framework.Scripts
{
    public class UnityHttpClientFactory : MonoBehaviour, IHttpClientFactory
    {
        [Tooltip("Адрес веб-сервера игры")]
        public string BaseUrl;

        public IHttpClient Open()
        {
            var authorizationHeader = Global.Authorization.GetAuthorizationHeader();
            var authorizationToken = Global.Authorization.GetAuthorizationToken();

            var httpClient = new UnityHttpClient(new Uri(BaseUrl), this);
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
