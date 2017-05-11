using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Decks;
using Arcomage.Domain.Rules;
using Arcomage.Unity.SettingsScene.ViewModels;
using Arcomage.Unity.Shared.Scripts;
using Autofac;

namespace Arcomage.Unity.Configuration
{
    public class SettingsSceneModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SettingsViewModel>()
                .OnActivated(ea => ea.Instance.Settings = ea.Context.Resolve<SingleSettings>())
                .OnActivated(ea => ea.Instance.DeckList = ea.Context.Resolve<DeckListViewModel>())
                .OnActivated(ea => ea.Instance.RuleList = ea.Context.Resolve<RuleListViewModel>())
                .InstancePerLifetimeScope();

            builder.RegisterType<DeckListViewModel>()
                .OnActivated(ea => ea.Instance.DeckCollection = new List<DeckViewModel>
                {
                    ea.Context.Resolve<DeckViewModel>(new NamedParameter("DeckInfo",
                        new ClassicDeckInfo("Classic", new Random()))),
                    ea.Context.Resolve<DeckViewModel>(new NamedParameter("DeckInfo",
                        new InfinityDeckInfo("Infinity", new Random()))),
                })
                .InstancePerLifetimeScope();

            builder.RegisterType<RuleListViewModel>()
                .OnActivated(ea => ea.Instance.RuleCollection = new List<RuleViewModel>
                {
                    ea.Context.Resolve<RuleViewModel>(new NamedParameter("RuleInfo",
                        new ClassicRuleInfo("EmpireCapital", 2, 5, 2, 5, 2, 5, 5, 20, 50, 150))),
                    ea.Context.Resolve<RuleViewModel>(new NamedParameter("RuleInfo",
                        new ClassicRuleInfo("TigersLake", 5, 25, 5, 25, 5, 25, 10, 20, 150, 400))),
                    ea.Context.Resolve<RuleViewModel>(new NamedParameter("RuleInfo",
                        new ClassicRuleInfo("EastRiver", 3, 5, 3, 5, 3, 5, 10, 20, 75, 200))),
                })
                .InstancePerLifetimeScope();

            builder.RegisterType<DeckViewModel>()
                .OnActivated(ea => ea.Instance.Settings = ea.Context.Resolve<SingleSettings>())
                .OnActivated(ea => ea.Instance.DeckInfo = ea.Parameters.Named<DeckInfo>("DeckInfo"));

            builder.RegisterType<RuleViewModel>()
                .OnActivated(ea => ea.Instance.Settings = ea.Context.Resolve<SingleSettings>())
                .OnActivated(ea => ea.Instance.RuleInfo = ea.Parameters.Named<ClassicRuleInfo>("RuleInfo"));
        }
    }
}
