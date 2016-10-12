using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Entities;
using Arcomage.Domain.GameConditions;
using Autofac;
using Autofac.Core;
using static Arcomage.MonoGame.Droid.CardRulesMode;

namespace Arcomage.MonoGame.Droid.Autofac
{
    public class GameConditionsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WinResultFactory>()
                .As<IWinResultFactory>()
                .SingleInstance();

            builder.Register(cc => cc.ResolveKeyed<GameCondition>(cc.Resolve<Settings>().CardRules))
                .As<GameCondition>();

            builder.RegisterType<ClassicGameCondition>()
                .Keyed<GameCondition>(BearMountain)
                .OnActivating(aea => Activate(aea, 1, 15, 1, 15, 1, 15, 10, 20, 200, 200, 500))
                .WithProperty(nameof(GameCondition.Identifier), nameof(BearMountain))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicGameCondition>()
                .Keyed<GameCondition>(CrystalGarden)
                .OnActivating(aea => Activate(aea, 4, 10, 4, 10, 4, 10, 15, 30, 100, 100, 300))
                .WithProperty(nameof(GameCondition.Identifier), nameof(CrystalGarden))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicGameCondition>()
                .Keyed<GameCondition>(DragonsCaves)
                .OnActivating(aea => Activate(aea, 5, 10, 5, 10, 5, 10, 10, 20, 150, 150, 400))
                .WithProperty(nameof(GameCondition.Identifier), nameof(DragonsCaves))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicGameCondition>()
                .Keyed<GameCondition>(EaglesNest)
                .OnActivating(aea => Activate(aea, 2, 5, 2, 5, 2, 5, 5, 20, 50, 50, 150))
                .WithProperty(nameof(GameCondition.Identifier), nameof(EaglesNest))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicGameCondition>()
                .Keyed<GameCondition>(EastRiver)
                .OnActivating(aea => Activate(aea, 3, 5, 3, 5, 3, 5, 10, 20, 75, 75, 200))
                .WithProperty(nameof(GameCondition.Identifier), nameof(EastRiver))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicGameCondition>()
                .Keyed<GameCondition>(EmpireCaptital)
                .OnActivating(aea => Activate(aea, 2, 5, 2, 5, 2, 5, 5, 20, 50, 50, 150))
                .WithProperty(nameof(GameCondition.Identifier), nameof(EmpireCaptital))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicGameCondition>()
                .Keyed<GameCondition>(FairyTrees)
                .OnActivating(aea => Activate(aea, 4, 10, 4, 10, 4, 10, 15, 30, 100, 100, 300))
                .WithProperty(nameof(GameCondition.Identifier), nameof(FairyTrees))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicGameCondition>()
                .Keyed<GameCondition>(FishingVillage)
                .OnActivating(aea => Activate(aea, 5, 25, 3, 13, 5, 25, 50, 50, 100, 100, 300))
                .WithProperty(nameof(GameCondition.Identifier), nameof(FishingVillage))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicGameCondition>()
                .Keyed<GameCondition>(GreenWood)
                .OnActivating(aea => Activate(aea, 4, 10, 4, 10, 4, 10, 15, 30, 100, 100, 300))
                .WithProperty(nameof(GameCondition.Identifier), nameof(GreenWood))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicGameCondition>()
                .Keyed<GameCondition>(KingdomCapital)
                .OnActivating(aea => Activate(aea, 3, 15, 1, 5, 2, 10, 10, 20, 125, 125, 350))
                .WithProperty(nameof(GameCondition.Identifier), nameof(KingdomCapital))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicGameCondition>()
                .Keyed<GameCondition>(KingdomCastle)
                .OnActivating(aea => Activate(aea, 3, 15, 1, 5, 2, 10, 10, 20, 125, 125, 350))
                .WithProperty(nameof(GameCondition.Identifier), nameof(KingdomCastle))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicGameCondition>()
                .Keyed<GameCondition>(LizardsLowland)
                .OnActivating(aea => Activate(aea, 1, 15, 1, 15, 1, 15, 10, 20, 200, 200, 500))
                .WithProperty(nameof(GameCondition.Identifier), nameof(LizardsLowland))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicGameCondition>()
                .Keyed<GameCondition>(MagmaMines)
                .OnActivating(aea => Activate(aea, 3, 15, 1, 5, 2, 10, 10, 20, 125, 125, 350))
                .WithProperty(nameof(GameCondition.Identifier), nameof(MagmaMines))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicGameCondition>()
                .Keyed<GameCondition>(MythrilCoast)
                .OnActivating(aea => Activate(aea, 3, 5, 3, 5, 3, 5, 10, 20, 75, 75, 200))
                .WithProperty(nameof(GameCondition.Identifier), nameof(MythrilCoast))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicGameCondition>()
                .Keyed<GameCondition>(PeacefulCamp)
                .OnActivating(aea => Activate(aea, 3, 15, 1, 5, 2, 10, 10, 20, 125, 125, 350))
                .WithProperty(nameof(GameCondition.Identifier), nameof(PeacefulCamp))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicGameCondition>()
                .Keyed<GameCondition>(PortCity)
                .OnActivating(aea => Activate(aea, 2, 5, 2, 5, 2, 5, 5, 20, 50, 50, 150))
                .WithProperty(nameof(GameCondition.Identifier), nameof(PortCity))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicGameCondition>()
                .Keyed<GameCondition>(PortalsRuins)
                .OnActivating(aea => Activate(aea, 3, 5, 3, 5, 3, 5, 10, 20, 75, 75, 200))
                .WithProperty(nameof(GameCondition.Identifier), nameof(PortalsRuins))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicGameCondition>()
                .Keyed<GameCondition>(RoguesWood)
                .OnActivating(aea => Activate(aea, 1, 6, 1, 6, 5, 30, 50, 20, 100, 100, 300))
                .WithProperty(nameof(GameCondition.Identifier), nameof(RoguesWood))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicGameCondition>()
                .Keyed<GameCondition>(ShiningSpring)
                .OnActivating(aea => Activate(aea, 1, 5, 1, 5, 5, 25, 50, 20, 100, 100, 300))
                .WithProperty(nameof(GameCondition.Identifier), nameof(ShiningSpring))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicGameCondition>()
                .Keyed<GameCondition>(SublimeArbor)
                .OnActivating(aea => Activate(aea, 5, 25, 5, 25, 5, 25, 10, 20, 150, 150, 400))
                .WithProperty(nameof(GameCondition.Identifier), nameof(SublimeArbor))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicGameCondition>()
                .Keyed<GameCondition>(SunnyCity)
                .OnActivating(aea => Activate(aea, 5, 25, 5, 25, 5, 25, 50, 50, 100, 100, 300))
                .WithProperty(nameof(GameCondition.Identifier), nameof(SunnyCity))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicGameCondition>()
                .Keyed<GameCondition>(TigersLake)
                .OnActivating(aea => Activate(aea, 5, 25, 5, 25, 5, 25, 10, 20, 150, 150, 400))
                .WithProperty(nameof(GameCondition.Identifier), nameof(TigersLake))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicGameCondition>()
                .Keyed<GameCondition>(TitansValley)
                .OnActivating(aea => Activate(aea, 5, 30, 5, 30, 5, 30, 10, 20, 150, 150, 400))
                .WithProperty(nameof(GameCondition.Identifier), nameof(TitansValley))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassicGameCondition>()
                .Keyed<GameCondition>(WolfsDale)
                .OnActivating(aea => Activate(aea, 5, 20, 3, 10, 5, 20, 50, 50, 100, 100, 300))
                .WithProperty(nameof(GameCondition.Identifier), nameof(WolfsDale))
                .InstancePerLifetimeScope();
        }

        private static void Activate(IActivatingEventArgs<ClassicGameCondition> activated, int quarry, int bricks, int magic, int gems, int dungeons, int recruits, int wall, int tower, int maxWall, int maxTower, int maxResources)
        {
            activated.Instance.Buildings = new Buildings { Wall = wall, Tower = tower };
            activated.Instance.Resources = new Resources { Quarry = quarry, Bricks = bricks, Magic = magic, Gems = gems, Dungeons = dungeons, Recruits = recruits };
            activated.Instance.MaxTower = maxTower;
            activated.Instance.MaxResources = maxResources;
        }

        // TODO Refactor to remove IWinResultFactory
        private class WinResultFactory : IWinResultFactory
        {
            public WinResult CreateBuildTowerWinResult(PlayerMode winPlayerMode)
            {
                throw new NotImplementedException();
            }

            public WinResult CreateDestroyTowerWinResult(PlayerMode winPlayerMode)
            {
                throw new NotImplementedException();
            }

            public WinResult CreateAccumulateResourcesWinResult(PlayerMode winPlayerMode)
            {
                throw new NotImplementedException();
            }
        }
    }
}