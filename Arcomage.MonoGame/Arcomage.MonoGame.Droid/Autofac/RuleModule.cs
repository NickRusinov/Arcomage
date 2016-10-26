using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Rules;
using Autofac;
using Autofac.Core;
using static Arcomage.MonoGame.Droid.RuleMode;

namespace Arcomage.MonoGame.Droid.Autofac
{
    public class RuleModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(cc => cc.ResolveKeyed<Rule>(cc.Resolve<Settings>().RuleMode))
                .As<Rule>();

            builder.RegisterType<ClassicRule>()
                .Keyed<Rule>(BearMountain)
                .OnActivating(aea => Activate(aea, 1, 15, 1, 15, 1, 15, 10, 20, 200, 200, 500))
                .WithProperty(nameof(Rule.Identifier), nameof(BearMountain))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicRule>()
                .Keyed<Rule>(CrystalGarden)
                .OnActivating(aea => Activate(aea, 4, 10, 4, 10, 4, 10, 15, 30, 100, 100, 300))
                .WithProperty(nameof(Rule.Identifier), nameof(CrystalGarden))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicRule>()
                .Keyed<Rule>(DragonsCaves)
                .OnActivating(aea => Activate(aea, 5, 10, 5, 10, 5, 10, 10, 20, 150, 150, 400))
                .WithProperty(nameof(Rule.Identifier), nameof(DragonsCaves))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicRule>()
                .Keyed<Rule>(EaglesNest)
                .OnActivating(aea => Activate(aea, 2, 5, 2, 5, 2, 5, 5, 20, 50, 50, 150))
                .WithProperty(nameof(Rule.Identifier), nameof(EaglesNest))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicRule>()
                .Keyed<Rule>(EastRiver)
                .OnActivating(aea => Activate(aea, 3, 5, 3, 5, 3, 5, 10, 20, 75, 75, 200))
                .WithProperty(nameof(Rule.Identifier), nameof(EastRiver))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicRule>()
                .Keyed<Rule>(EmpireCaptital)
                .OnActivating(aea => Activate(aea, 2, 5, 2, 5, 2, 5, 5, 20, 50, 50, 150))
                .WithProperty(nameof(Rule.Identifier), nameof(EmpireCaptital))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicRule>()
                .Keyed<Rule>(FairyTrees)
                .OnActivating(aea => Activate(aea, 4, 10, 4, 10, 4, 10, 15, 30, 100, 100, 300))
                .WithProperty(nameof(Rule.Identifier), nameof(FairyTrees))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicRule>()
                .Keyed<Rule>(FishingVillage)
                .OnActivating(aea => Activate(aea, 5, 25, 3, 13, 5, 25, 50, 50, 100, 100, 300))
                .WithProperty(nameof(Rule.Identifier), nameof(FishingVillage))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicRule>()
                .Keyed<Rule>(GreenWood)
                .OnActivating(aea => Activate(aea, 4, 10, 4, 10, 4, 10, 15, 30, 100, 100, 300))
                .WithProperty(nameof(Rule.Identifier), nameof(GreenWood))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicRule>()
                .Keyed<Rule>(KingdomCapital)
                .OnActivating(aea => Activate(aea, 3, 15, 1, 5, 2, 10, 10, 20, 125, 125, 350))
                .WithProperty(nameof(Rule.Identifier), nameof(KingdomCapital))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicRule>()
                .Keyed<Rule>(KingdomCastle)
                .OnActivating(aea => Activate(aea, 3, 15, 1, 5, 2, 10, 10, 20, 125, 125, 350))
                .WithProperty(nameof(Rule.Identifier), nameof(KingdomCastle))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicRule>()
                .Keyed<Rule>(LizardsLowland)
                .OnActivating(aea => Activate(aea, 1, 15, 1, 15, 1, 15, 10, 20, 200, 200, 500))
                .WithProperty(nameof(Rule.Identifier), nameof(LizardsLowland))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicRule>()
                .Keyed<Rule>(MagmaMines)
                .OnActivating(aea => Activate(aea, 3, 15, 1, 5, 2, 10, 10, 20, 125, 125, 350))
                .WithProperty(nameof(Rule.Identifier), nameof(MagmaMines))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicRule>()
                .Keyed<Rule>(MythrilCoast)
                .OnActivating(aea => Activate(aea, 3, 5, 3, 5, 3, 5, 10, 20, 75, 75, 200))
                .WithProperty(nameof(Rule.Identifier), nameof(MythrilCoast))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicRule>()
                .Keyed<Rule>(PeacefulCamp)
                .OnActivating(aea => Activate(aea, 3, 15, 1, 5, 2, 10, 10, 20, 125, 125, 350))
                .WithProperty(nameof(Rule.Identifier), nameof(PeacefulCamp))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicRule>()
                .Keyed<Rule>(PortCity)
                .OnActivating(aea => Activate(aea, 2, 5, 2, 5, 2, 5, 5, 20, 50, 50, 150))
                .WithProperty(nameof(Rule.Identifier), nameof(PortCity))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicRule>()
                .Keyed<Rule>(PortalsRuins)
                .OnActivating(aea => Activate(aea, 3, 5, 3, 5, 3, 5, 10, 20, 75, 75, 200))
                .WithProperty(nameof(Rule.Identifier), nameof(PortalsRuins))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicRule>()
                .Keyed<Rule>(RoguesWood)
                .OnActivating(aea => Activate(aea, 1, 6, 1, 6, 5, 30, 50, 20, 100, 100, 300))
                .WithProperty(nameof(Rule.Identifier), nameof(RoguesWood))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicRule>()
                .Keyed<Rule>(ShiningSpring)
                .OnActivating(aea => Activate(aea, 1, 5, 1, 5, 5, 25, 50, 20, 100, 100, 300))
                .WithProperty(nameof(Rule.Identifier), nameof(ShiningSpring))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicRule>()
                .Keyed<Rule>(SublimeArbor)
                .OnActivating(aea => Activate(aea, 5, 25, 5, 25, 5, 25, 10, 20, 150, 150, 400))
                .WithProperty(nameof(Rule.Identifier), nameof(SublimeArbor))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicRule>()
                .Keyed<Rule>(SunnyCity)
                .OnActivating(aea => Activate(aea, 5, 25, 5, 25, 5, 25, 50, 50, 100, 100, 300))
                .WithProperty(nameof(Rule.Identifier), nameof(SunnyCity))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicRule>()
                .Keyed<Rule>(TigersLake)
                .OnActivating(aea => Activate(aea, 5, 25, 5, 25, 5, 25, 10, 20, 150, 150, 400))
                .WithProperty(nameof(Rule.Identifier), nameof(TigersLake))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicRule>()
                .Keyed<Rule>(TitansValley)
                .OnActivating(aea => Activate(aea, 5, 30, 5, 30, 5, 30, 10, 20, 150, 150, 400))
                .WithProperty(nameof(Rule.Identifier), nameof(TitansValley))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicRule>()
                .Keyed<Rule>(WolfsDale)
                .OnActivating(aea => Activate(aea, 5, 20, 3, 10, 5, 20, 50, 50, 100, 100, 300))
                .WithProperty(nameof(Rule.Identifier), nameof(WolfsDale))
                .InstancePerLifetimeScope();
        }

        private static void Activate(IActivatingEventArgs<ClassicRule> activated, int quarry, int bricks, int magic, int gems, int dungeons, int recruits, int wall, int tower, int maxWall, int maxTower, int maxResources)
        {
            activated.Instance.Buildings = new Buildings { Wall = wall, Tower = tower };
            activated.Instance.Resources = new Resources { Quarry = quarry, Bricks = bricks, Magic = magic, Gems = gems, Dungeons = dungeons, Recruits = recruits };
            activated.Instance.MaxTower = maxTower;
            activated.Instance.MaxResources = maxResources;
        }
    }
}