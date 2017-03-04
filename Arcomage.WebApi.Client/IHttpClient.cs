using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.WebApi.Client
{
    public interface IHttpClient
    {
        Task<string> Get(string url);

        Task<string> Post(string url, IDictionary<string, string> data);
    }
}
