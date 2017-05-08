using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Arcomage.Domain.Actions;
using Arcomage.Domain.ArtificialIntelligence;
using Arcomage.Domain.Cards;
using Arcomage.Domain.Decks;
using Arcomage.Domain.Hands;
using Arcomage.Domain.Histories;
using Arcomage.Domain.Players;
using Arcomage.Domain.Rules;
using Arcomage.Domain.Timers;

namespace Arcomage.Domain
{
    /// <summary>
    /// Методы расширения для конфигурации строителя, предназначенного для создания объектов игровой логики
    /// </summary>
    public static class GameBuilderExtensions
    {
        public static GameBuilder<T> GetDefault<T>()
        {
            return new GameBuilder<T>()
                .RegisterGame(null)
                .RegisterPlayAction(null)
                .RegisterAllCard(null)
                .RegisterHistory(null)
                .RegisterFirstHumanPlayer(null)
                .RegisterSecondHumanPlayer(null)
                .RegisterArtificialIntelligence(null)
                .RegisterInfinityTimer(null)
                .RegisterPlayerSet(null, _ => PlayerKind.First)
                .RegisterClassicRule(null, _ => new ClassicRuleInfo("Classic", 2, 5, 2, 5, 2, 5, 5, 20, 50, 150))
                .RegisterClassicDeck(null, _ => new ClassicDeckInfo("Classic", new Random()));
        }

        public static GameBuilder<T> With<T>(this GameBuilder<T> builder, Type type, Func<T, string> keySelector)
        {
            return builder.Register(b =>
                b.Resolve(type, keySelector.Invoke(b.State)));
        }

        public static GameBuilder<T> RegisterGame<T>(this GameBuilder<T> builder, string key)
        {
            return builder.Register(b => 
                new Game(
                    b.Resolve<IPlayAction>(),
                    b.Resolve<Rule>(), 
                    b.Resolve<Deck>(), 
                    b.Resolve<History>(), 
                    b.Resolve<PlayerSet>(), 
                    b.Resolve<Timer>()));
        }

        public static GameBuilder<T> RegisterClassicRule<T>(this GameBuilder<T> builder, string key, Func<T, ClassicRuleInfo> ruleInfoFactory)
        {
            return builder.Register<Rule>(key, b =>
                new ClassicRule(ruleInfoFactory.Invoke(b.State)));
        }

        public static GameBuilder<T> RegisterClassicDeck<T>(this GameBuilder<T> builder, string key, Func<T, ClassicDeckInfo> ruleInfoFactory)
        {
            return builder.Register<Deck>(key, b =>
                new ClassicDeck(ruleInfoFactory.Invoke(b.State), b.Resolve<ICollection<Card>>()));
        }

        public static GameBuilder<T> RegisterInfinityDeck<T>(this GameBuilder<T> builder, string key, Func<T, InfinityDeckInfo> ruleInfoFactory)
        {
            return builder.Register<Deck>(key, b =>
                new InfinityDeck(ruleInfoFactory.Invoke(b.State), b.Resolve<ICollection<Card>>()));
        }

        public static GameBuilder<T> RegisterAllCard<T>(this GameBuilder<T> builder, string key)
        {
            return builder.Register<ICollection<Card>>(b =>
                Assembly.GetExecutingAssembly().GetTypes()
                .Where(typeof(Card).IsAssignableFrom)
                .Where(t => !t.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<Card>().ToArray());
        }

        public static GameBuilder<T> RegisterHistory<T>(this GameBuilder<T> builder, string key)
        {
            return builder.Register(b => 
                new History(new HistoryCard[0]));
        }

        public static GameBuilder<T> RegisterPlayerSet<T>(this GameBuilder<T> builder, string key, Func<T, PlayerKind> playerKindFactory)
        {
            return builder.Register(b =>
                new PlayerSet(
                    playerKindFactory.Invoke(b.State), 
                    b.Resolve<Player>("FirstPlayer"), 
                    b.Resolve<Player>("SecondPlayer")));
        }

        public static GameBuilder<T> RegisterFirstHumanPlayer<T>(this GameBuilder<T> builder, string key)
        {
            return builder.Register<Player>(key ?? "FirstPlayer", b =>
                new HumanPlayer(
                    b.Resolve<Rule>().CreateBuildings(), 
                    b.Resolve<Rule>().CreateResources(), 
                    new Hand(Enumerable.Repeat(b.Resolve<Deck>(), 6).Select(d => d.PopCard(null)).ToArray())));
        }

        public static GameBuilder<T> RegisterSecondHumanPlayer<T>(this GameBuilder<T> builder, string key)
        {
            return builder.Register<Player>(key ?? "SecondPlayer", b =>
                new HumanPlayer(
                    b.Resolve<Rule>().CreateBuildings(),
                    b.Resolve<Rule>().CreateResources(),
                    new Hand(Enumerable.Repeat(b.Resolve<Deck>(), 6).Select(d => d.PopCard(null)).ToArray())));
        }

        public static GameBuilder<T> RegisterFirstComputerPlayer<T>(this GameBuilder<T> builder, string key)
        {
            return builder.Register<Player>(key ?? "FirstPlayer", b =>
                new ComputerPlayer(
                    b.Resolve<IArtificialIntelligence>(),
                    b.Resolve<Rule>().CreateBuildings(),
                    b.Resolve<Rule>().CreateResources(),
                    new Hand(Enumerable.Repeat(b.Resolve<Deck>(), 6).Select(d => d.PopCard(null)).ToArray())));
        }

        public static GameBuilder<T> RegisterSecondComputerPlayer<T>(this GameBuilder<T> builder, string key)
        {
            return builder.Register<Player>(key ?? "SecondPlayer", b =>
                new ComputerPlayer(
                    b.Resolve<IArtificialIntelligence>(),
                    b.Resolve<Rule>().CreateBuildings(),
                    b.Resolve<Rule>().CreateResources(),
                    new Hand(Enumerable.Repeat(b.Resolve<Deck>(), 6).Select(d => d.PopCard(null)).ToArray())));
        }
        
        public static GameBuilder<T> WithFirstPlayer<T>(this GameBuilder<T> builder, Func<T, string> playerKeyFactory)
        {
            return builder.Register("FirstPlayer", b =>
                b.Resolve<Player>(playerKeyFactory.Invoke(b.State)));
        }

        public static GameBuilder<T> WithSecondPlayer<T>(this GameBuilder<T> builder, Func<T, string> playerKeyFactory)
        {
            return builder.Register("SecondPlayer", b =>
                b.Resolve<Player>(playerKeyFactory.Invoke(b.State)));
        }

        public static GameBuilder<T> RegisterFixedTimer<T>(this GameBuilder<T> builder, string key, Func<T, TimeSpan> periodFactory)
        {
            return builder.Register<Timer>(key, b =>
                new FixedTimer(periodFactory.Invoke(b.State)));
        }

        public static GameBuilder<T> RegisterInfinityTimer<T>(this GameBuilder<T> builder, string key)
        {
            return builder.Register<Timer>(key, b =>
                new InfinityTimer());
        }
        
        public static GameBuilder<T> RegisterArtificialIntelligence<T>(this GameBuilder<T> builder, string key)
        {
            return builder.Register<IArtificialIntelligence>(key, b =>
                new ArtificialIntelligence.ArtificialIntelligence(
                    b.Resolve<IPlayAction>()));
        }

        public static GameBuilder<T> RegisterFakeAftificialIntelligence<T>(this GameBuilder<T> builder, string key)
        {
            return builder.Register<IArtificialIntelligence>(key, b =>
                new FakeArtificialIntelligence(
                    b.Resolve<IPlayAction>()));
        }

        public static GameBuilder<T> RegisterPlayAction<T>(this GameBuilder<T> builder, string key)
        {
            return builder.Register<IPlayAction>(key, b =>
            {
                var terminatePlayAction = new TerminatePlayAction();
                var increaseResourcesAction = new IncreaseResourcesAction(terminatePlayAction);
                var replacePlayerAction = new ReplacePlayerAction(increaseResourcesAction, terminatePlayAction);
                var finishBeforeReplacePlayerAction = new FinishGameAction(replacePlayerAction);
                var replaceCardAction = new ReplaceCardAction(finishBeforeReplacePlayerAction);
                var addHistoryAction = new AddHistoryAction(replaceCardAction);
                var activateCardAction = new ActivateCardAction(addHistoryAction);
                var finishedPlayAction = new FinishGameAction(activateCardAction);
                var rootPlayAction = new RootPlayAction(finishedPlayAction);

                return rootPlayAction;
            });
        }
    }
}
