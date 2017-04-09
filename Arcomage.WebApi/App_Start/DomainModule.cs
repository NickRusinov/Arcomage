using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Arcomage.Domain;
using Autofac;

namespace Arcomage.WebApi
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c =>
                GameBuilderExtensions.GetDefault()
                    .RegisterFirstHumanPlayer(null)
                    .RegisterSecondComputerPlayer(null))
                .AsSelf()
                .SingleInstance();
        }
    }
}