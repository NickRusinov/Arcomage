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
using Arcomage.Domain.Services;
using Arcomage.Domain.Timers;

namespace Arcomage.Domain
{
    public static class GameBuilderExtensions
    {
        public static GameBuilder GetDefault()
        {
            return new GameBuilder()
                .RegisterGame(null)
                .RegisterPlayAction(null)
                .RegisterPlayCardCriteria(null)
                .RegisterDiscardCardCriteria(null)
                .RegisterAllCard(null)
                .RegisterHistory(null)
                .RegisterFirstHumanPlayer(null)
                .RegisterSecondHumanPlayer(null)
                .RegisterArtificialIntelligence(null)
                .RegisterInfinityTimer(null)
                .RegisterPlayerSet(null, () => PlayerKind.First)
                .RegisterClassicRule(null, () => new ClassicRuleInfo("Classic", 2, 5, 2, 5, 2, 5, 5, 20, 50, 150))
                .RegisterClassicDeck(null, () => new ClassicDeckInfo("Classic", new Random()));
        }

        public static GameBuilder With<T>(this GameBuilder builder, Func<string> keySelector)
        {
            return builder.Register(b =>
                b.Resolve<T>(keySelector.Invoke()));
        }

        public static GameBuilder RegisterGame(this GameBuilder builder, string key)
        {
            return builder.Register(b => 
                new Game(
                    b.Resolve<Rule>(), 
                    b.Resolve<Deck>(), 
                    b.Resolve<History>(), 
                    b.Resolve<PlayerSet>(), 
                    b.Resolve<Timer>()));
        }

        public static GameBuilder RegisterClassicRule(this GameBuilder builder, string key, Func<ClassicRuleInfo> ruleInfoFactory)
        {
            return builder.Register<Rule>(key, b =>
                new ClassicRule(ruleInfoFactory.Invoke()));
        }

        public static GameBuilder RegisterClassicDeck(this GameBuilder builder, string key, Func<ClassicDeckInfo> ruleInfoFactory)
        {
            return builder.Register<Deck>(key, b =>
                new ClassicDeck(ruleInfoFactory.Invoke(), b.Resolve<ICollection<Card>>()));
        }

        public static GameBuilder RegisterInfinityDeck(this GameBuilder builder, string key, Func<InfinityDeckInfo> ruleInfoFactory)
        {
            return builder.Register<Deck>(key, b =>
                new InfinityDeck(ruleInfoFactory.Invoke(), b.Resolve<ICollection<Card>>()));
        }

        public static GameBuilder RegisterAllCard(this GameBuilder builder, string key)
        {
            return builder.Register<ICollection<Card>>(b =>
                Assembly.GetExecutingAssembly().GetTypes()
                .Where(typeof(Card).IsAssignableFrom)
                .Where(t => !t.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<Card>().ToArray());
        }

        public static GameBuilder RegisterHistory(this GameBuilder builder, string key)
        {
            return builder.Register(b => 
                new History(new HistoryCard[0]));
        }

        public static GameBuilder RegisterPlayerSet(this GameBuilder builder, string key, Func<PlayerKind> playerKindFactory)
        {
            return builder.Register(b =>
                new PlayerSet(
                    playerKindFactory.Invoke(), 
                    b.Resolve<Player>("FirstPlayer"), 
                    b.Resolve<Player>("SecondPlayer")));
        }

        public static GameBuilder RegisterFirstHumanPlayer(this GameBuilder builder, string key)
        {
            return builder.Register<Player>(key ?? "FirstPlayer", b =>
                new HumanPlayer(
                    b.Resolve<Rule>().CreateBuildings(), 
                    b.Resolve<Rule>().CreateResources(), 
                    new Hand(Enumerable.Repeat(b.Resolve<Deck>(), 6).Select(d => d.PopCard(null)).ToArray())));
        }

        public static GameBuilder RegisterSecondHumanPlayer(this GameBuilder builder, string key)
        {
            return builder.Register<Player>(key ?? "SecondPlayer", b =>
                new HumanPlayer(
                    b.Resolve<Rule>().CreateBuildings(),
                    b.Resolve<Rule>().CreateResources(),
                    new Hand(Enumerable.Repeat(b.Resolve<Deck>(), 6).Select(d => d.PopCard(null)).ToArray())));
        }

        public static GameBuilder RegisterFirstComputerPlayer(this GameBuilder builder, string key)
        {
            return builder.Register<Player>(key ?? "FirstPlayer", b =>
                new ComputerPlayer(
                    b.Resolve<IArtificialIntelligence>(),
                    b.Resolve<Rule>().CreateBuildings(),
                    b.Resolve<Rule>().CreateResources(),
                    new Hand(Enumerable.Repeat(b.Resolve<Deck>(), 6).Select(d => d.PopCard(null)).ToArray())));
        }

        public static GameBuilder RegisterSecondComputerPlayer(this GameBuilder builder, string key)
        {
            return builder.Register<Player>(key ?? "SecondPlayer", b =>
                new ComputerPlayer(
                    b.Resolve<IArtificialIntelligence>(),
                    b.Resolve<Rule>().CreateBuildings(),
                    b.Resolve<Rule>().CreateResources(),
                    new Hand(Enumerable.Repeat(b.Resolve<Deck>(), 6).Select(d => d.PopCard(null)).ToArray())));
        }
        
        public static GameBuilder WithFirstPlayer(this GameBuilder builder, Func<string> playerKeyFactory)
        {
            return builder.Register("FirstPlayer", b =>
                b.Resolve<Player>(playerKeyFactory.Invoke()));
        }

        public static GameBuilder WithSecondPlayer(this GameBuilder builder, Func<string> playerKeyFactory)
        {
            return builder.Register("SecondPlayer", b =>
                b.Resolve<Player>(playerKeyFactory.Invoke()));
        }

        public static GameBuilder RegisterFixedTimer(this GameBuilder builder, string key, Func<TimeSpan> periodFactory)
        {
            return builder.Register<Timer>(key, b =>
                new FixedTimer(periodFactory.Invoke()));
        }

        public static GameBuilder RegisterInfinityTimer(this GameBuilder builder, string key)
        {
            return builder.Register<Timer>(key, b =>
                new InfinityTimer());
        }
        
        public static GameBuilder RegisterArtificialIntelligence(this GameBuilder builder, string key)
        {
            return builder.Register<IArtificialIntelligence>(key, b =>
                new ArtificialIntelligence.ArtificialIntelligence(
                    CreateArtificialIntelligencePlayCardAction(b),
                    b.Resolve<IPlayCardCriteria>(),
                    b.Resolve<IDiscardCardCriteria>()));

            IPlayCardAction CreateArtificialIntelligencePlayCardAction(GameBuilderContext context)
            {
                var terminatePlayAction = new TerminatePlayAction();
                var finishGameAction = new FinishGameAction(terminatePlayAction);
                var increaseResourcesAction = new IncreaseResourcesAction(finishGameAction);
                var clearHistoryAction = new ClearHistoryAction(increaseResourcesAction);
                var replacePlayerAction = new ReplacePlayerAction(clearHistoryAction, finishGameAction);

                var terminatePlayCardAction = new TerminatePlayCardAction();
                var adapterPlayCardAction = new AdapterPlayCardAction(terminatePlayCardAction, replacePlayerAction);
                var replaceCardAction = new ReplaceCardAction(adapterPlayCardAction);
                var addHistoryAction = new AddHistoryAction(replaceCardAction);
                var playCardAction = new ActivateCardAction(addHistoryAction);

                return playCardAction;
            }
        }

        public static GameBuilder RegisterFakeAftificialIntelligence(this GameBuilder builder, string key)
        {
            return builder.Register<IArtificialIntelligence>(key, b =>
                new FakeArtificialIntelligence(
                    b.Resolve<IPlayCardCriteria>()));
        }

        public static GameBuilder RegisterPlayCardCriteria(this GameBuilder builder, string key)
        {
            return builder.Register<IPlayCardCriteria>(b =>
                new PlayCardCriteria());
        }

        public static GameBuilder RegisterDiscardCardCriteria(this GameBuilder builder, string key)
        {
            return builder.Register<IDiscardCardCriteria>(b =>
                new DiscardCardCriteria());
        }

        public static GameBuilder RegisterPlayAction(this GameBuilder builder, string key)
        {
            return builder.Register<IPlayAction>(b =>
            {
                var terminatePlayCardAction = new TerminatePlayCardAction();
                var replaceCardAction = new ReplaceCardAction(terminatePlayCardAction);
                var addHistoryAction = new AddHistoryAction(replaceCardAction);
                var activateCardAction = new ActivateCardAction(addHistoryAction);

                var terminatePlayAction = new TerminatePlayAction();
                var finishAfterPlayPlayerAction = new FinishGameAction(terminatePlayAction);
                var playPlayerAction = new PlayPlayerAction(finishAfterPlayPlayerAction, activateCardAction);
                var finishBeforePlayPlayerAction = new FinishGameAction(playPlayerAction);

                var increaseResourcesAction = new IncreaseResourcesAction(finishBeforePlayPlayerAction);
                var clearHistoryAction = new ClearHistoryAction(increaseResourcesAction);
                var replacePlayerAction = new ReplacePlayerAction(clearHistoryAction, finishBeforePlayPlayerAction);
                var playAction = new FinishGameAction(replacePlayerAction);

                return playAction;
            });
        }
    }
}
