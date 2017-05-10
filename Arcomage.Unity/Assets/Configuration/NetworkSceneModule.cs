using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Unity.NetworkScene.Requests;
using Autofac;

namespace Arcomage.Unity.Configuration
{
    public class NetworkSceneModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConnectGameRequestHandler>()
                .AsImplementedInterfaces();

            builder.RegisterType<DisconnectGameRequestHandler>()
                .AsImplementedInterfaces();

            builder.RegisterType<GetConnectingGameRequestHandler>()
                .AsImplementedInterfaces();

            builder.RegisterType<GetVersionRequestHandler>()
                .AsImplementedInterfaces();

            builder.RegisterType<PlayRequestHandler>()
                .AsImplementedInterfaces();
        }
    }
}
