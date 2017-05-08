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
                GameBuilderExtensions.GetDefault<SingleSettings>()
                    .RegisterFirstHumanPlayer("FirstFirstPlayer")
                    .RegisterSecondComputerPlayer("FirstSecondPlayer")
                    .RegisterFirstComputerPlayer("SecondFirstPlayer")
                    .RegisterSecondHumanPlayer("SecondSecondPlayer")
                    .RegisterFixedTimer(null, s => TimeSpan.FromSeconds(30))
                    .RegisterPlayerSet(null, s => new Random().Next(100) < 50 ? PlayerKind.First : PlayerKind.Second)
                    .RegisterClassicRule(null, s => (ClassicRuleInfo)s.Rule)
                    .RegisterClassicDeck("ClassicDeck", s => (ClassicDeckInfo)s.Deck)
                    .RegisterInfinityDeck("InfinityDeck", s => (InfinityDeckInfo)s.Deck)
                    .WithFirstPlayer(s => s.PlayerKind + "FirstPlayer")
                    .WithSecondPlayer(s => s.PlayerKind + "SecondPlayer")
                    .With(typeof(Deck), s => s.Deck.Identifier + "Deck"))
                .SingleInstance();

            builder.Register(c => c.Resolve<SingleSettings>().GameBuilderContext ?? 
                    c.Resolve<GameBuilder<SingleSettings>>().CreateContext(c.Resolve<SingleSettings>()))
                .InstancePerLifetimeScope();

            builder.Register(c => c.Resolve<GameBuilderContext<SingleSettings>>().Resolve<Game>())
                .InstancePerLifetimeScope();

            builder.Register(c => c.Resolve<GameBuilderContext<SingleSettings>>().Resolve<IPlayAction>())
                .InstancePerLifetimeScope();

            builder.Register(c => c.Resolve<Game>().Players.FirstPlayer as HumanPlayer ?? 
                    c.Resolve<Game>().Players.SecondPlayer as HumanPlayer)
                .InstancePerLifetimeScope();
        }
    }
}