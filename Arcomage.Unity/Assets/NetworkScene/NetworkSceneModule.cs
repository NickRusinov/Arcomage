using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Unity.NetworkScene.Commands;
using Arcomage.Unity.NetworkScene.ViewModels;
using Autofac;

namespace Arcomage.Unity.NetworkScene
{
    public class NetworkSceneModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConnectViewModel>()
                .OnActivated(ea => ea.Instance.GetVersionCommand = ea.Context.Resolve<GetVersionCommand>())
                .InstancePerLifetimeScope();

            builder.RegisterType<PrepareViewModel>()
                .OnActivated(ea => ea.Instance.ConnectCommand = ea.Context.Resolve<ConnectGameCommand>())
                .OnActivated(ea => ea.Instance.DisconnectCommand = ea.Context.Resolve<DisconnectGameCommand>())
                .InstancePerLifetimeScope();
        }
    }
}
