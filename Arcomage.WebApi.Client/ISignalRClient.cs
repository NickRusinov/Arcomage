using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNet.SignalR.Client;

namespace Arcomage.WebApi.Client
{
    public interface ISignalRClient
    {
        HubConnection Open();

        void Close(HubConnection connection);
    }
}
