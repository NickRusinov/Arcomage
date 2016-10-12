using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Entities;
using Autofac;

namespace Arcomage.MonoGame.Droid.Autofac
{
    public class CardsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Game).Assembly)
                .AssignableTo<Card>()
                .As<Card>()
                .OnActivating(aea => ((Card)aea.Instance).Identifier = GetCardIdentifier(aea.Instance.GetType().Name))
                .InstancePerLifetimeScope();
        }

        private static string GetCardIdentifier(string cardTypeName)
        {
            if (cardTypeName.EndsWith("Card"))
                return cardTypeName.Substring(0, cardTypeName.Length - 4);

            return cardTypeName;
        }
    }
}