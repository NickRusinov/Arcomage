using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Actions;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Services;
using Autofac;
using static Arcomage.Domain.Entities.PlayerMode;

namespace Arcomage.MonoGame.Droid.Autofac
{
    public class ActionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(cc =>
                new CompositePlayAction(
                    new WhenReplacedPlayerAction(
                        new CompositePlayAction(
                            new ClearHistoryAction(),
                            new UpdateResourcesAction(),
                            new UpdateFinishedAction(cc.Resolve<Rule>()))),
                    cc.Resolve<UpdateViewGameAction>()))
                .As<IPlayAction>();

            builder.Register(cc =>
                new CompositeCardAction(
                    new ActivateCardAction(),
                    new UpdateHistoryAction(),
                    new ReplaceCardAction(),
                    new ReplacePlayerAction(),
                    new UpdateFinishedAction(cc.Resolve<Rule>()),
                    cc.Resolve<UpdateViewGameAction>()))
                .As<ICardAction>();
                    
            builder.Register(cc => new PlayCardCriteria(FirstPlayer))
                .As<IPlayCardCriteria>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DiscardCardCriteria>()
                .As<IDiscardCardCriteria>()
                .InstancePerLifetimeScope();
        }
    }
}