using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain;
using Arcomage.Domain.Actions;
using Arcomage.Domain.Decks;
using Arcomage.Domain.Players;
using Arcomage.Domain.Rules;
using Arcomage.Unity.Shared.Scripts;
using Autofac;

namespace Arcomage.Unity.Configuration
{
    /// <summary>
    /// Модуль, устанавливающий зависимости игровой логики
    /// </summary>
    public class SingleGameSceneModule : Module
    {
        /// <summary>
        /// Настройка привязок контейнера внедрения зависимостей
        /// </summary>
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c =>
                GameBuilderExtensions.GetDefault()
                    .RegisterFirstHumanPlayer(null)
                    .RegisterSecondComputerPlayer(null)
                    .RegisterFixedTimer(null, () => TimeSpan.FromSeconds(30))
                    .RegisterPlayerSet(null, () => new Random().Next(100) < 50 ? PlayerKind.First : PlayerKind.Second)
                    .RegisterClassicRule(null, () => (ClassicRuleInfo)c.Resolve<SingleSettings>().Rule)
                    .RegisterClassicDeck("ClassicDeck", () => (ClassicDeckInfo)c.Resolve<SingleSettings>().Deck)
                    .RegisterInfinityDeck("InfinityDeck", () => (InfinityDeckInfo)c.Resolve<SingleSettings>().Deck)
                    .With<Deck>(() => c.Resolve<SingleSettings>().Deck.Identifier + "Deck"))
                .InstancePerLifetimeScope();

            builder.Register(c => c.Resolve<GameBuilder>().CreateContext())
                .InstancePerLifetimeScope();

            builder.Register(c => c.Resolve<GameBuilderContext>().Resolve<Game>())
                .InstancePerLifetimeScope();

            builder.Register(c => c.Resolve<GameBuilderContext>().Resolve<IPlayAction>())
                .InstancePerLifetimeScope();

            builder.Register(c => (HumanPlayer)c.Resolve<Game>().Players.FirstPlayer)
                .InstancePerLifetimeScope();
        }
    }
}