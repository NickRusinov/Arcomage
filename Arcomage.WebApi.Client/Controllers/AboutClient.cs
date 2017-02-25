using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.WebApi.Client.Models.About;

namespace Arcomage.WebApi.Client.Controllers
{
    public class AboutClient : ControllerClient
    {
        public AboutClient(string baseUrl, string authenticate)
            : base(baseUrl, authenticate)
        {
            
        }
        
        public Task<VersionModel> GetVersion()
        {
            return Get<VersionModel>("api/version");
        }
    }
}
