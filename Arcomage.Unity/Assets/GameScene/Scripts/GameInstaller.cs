using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain;
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
using Arcomage.Unity.GameScene.Commands;
using Arcomage.Unity.GameScene.ViewModels;
using Arcomage.Unity.Shared.Scripts;
using Zenject;

namespace Arcomage.Unity.GameScene.Scripts
{
    /// <summary>
    /// Модуль, устанавливающий зависимости игровой логики
    /// </summary>
    public class GameInstaller : Installer<GameInstaller>
    {
        /// <summary>
        /// Настройка привязок контейнера внедрения зависимостей
        /// </summary>
        public override void InstallBindings()
        {
            Container.Bind<ClassicRuleInfo>()
                .FromMethod(c => (ClassicRuleInfo)Settings.Instance.Rule);

            Container.Bind<DeckInfo>()
                .FromMethod(c => Settings.Instance.Deck);

            Container.Bind<IArtificialIntelligence>()
                .To<ArtificialIntelligence>()
                .AsSingle(0);

            Container.Bind<Card>()
                .To(b => b.AllNonAbstractClasses()
                    .FromAssemblyContaining<Card>())
                .AsSingle(0);

            Container.Bind<IPlayCardAction>()
                .FromMethod(c => CreatePlayCardAction(c.Container))
                .AsSingle(0);

            Container.Bind<IPlayAction>()
                .FromMethod(c => CreatePlayAction(c.Container))
                .AsSingle(0);

            Container.Bind<IPlayCardCriteria>()
                .To<PlayCardCriteria>()
                .AsSingle(0);

            Container.Bind<IDiscardCardCriteria>()
                .To<DiscardCardCriteria>()
                .AsSingle(0);

            Container.Bind<Game>()
                .ToSelf()
                .AsSingle(0);

            Container.Bind<PlayerSet>()
                .FromMethod(c => new PlayerSet(
                    c.Container.Resolve<PlayerKind>(),
                    c.Container.Resolve<Player>("FirstPlayer"),
                    c.Container.Resolve<Player>("SecondPlayer")))
                .AsSingle(0);

            Container.Bind<PlayerKind>()
                .FromMethod(c => new Random().Next(100) < 50 ? PlayerKind.First : PlayerKind.Second)
                .AsSingle(0);

            Container.Bind<Player>()
                .WithId("FirstPlayer")
                .FromMethod(c => new HumanPlayer(
                    c.Container.Resolve<Rule>().CreateBuildings(),
                    c.Container.Resolve<Rule>().CreateResources(),
                    c.Container.Resolve<Hand>("FirstPlayer")))
                .AsSingle(0);

            Container.Bind<Player>()
                .WithId("SecondPlayer")
                .FromMethod(c => new ComputerPlayer(
                    c.Container.Resolve<IArtificialIntelligence>(),
                    c.Container.Resolve<Rule>().CreateBuildings(),
                    c.Container.Resolve<Rule>().CreateResources(),
                    c.Container.Resolve<Hand>("SecondPlayer")))
                .AsSingle(1);

            Container.Bind<HumanPlayer>()
                .FromMethod(c => (HumanPlayer)c.Container.Resolve<Player>("FirstPlayer"))
                .AsSingle(0);

            Container.Bind<History>()
                .FromMethod(c => new History(Enumerable.Empty<HistoryCard>().ToList()))
                .AsSingle(0);

            Container.Bind<Hand>()
                .WithId("FirstPlayer")
                .FromMethod(c => new Hand(
                    Enumerable.Repeat(c.Container.Resolve<Deck>(), 6).Select(d => d.PopCard(null)).ToList()))
                .AsSingle(0);

            Container.Bind<Hand>()
                .WithId("SecondPlayer")
                .FromMethod(c => new Hand(
                    Enumerable.Repeat(c.Container.Resolve<Deck>(), 6).Select(d => d.PopCard(null)).ToList()))
                .AsSingle(1);

            Container.Bind<Deck>()
                .FromMethod(c => c.Container.Resolve<Deck>(Settings.Instance.Deck.Identifier))
                .AsSingle(0);

            Container.Bind<Deck>()
                .WithId("Classic")
                .FromMethod(c => new ClassicDeck(
                    (ClassicDeckInfo)Settings.Instance.Deck, 
                    c.Container.ResolveAll<Card>()))
                .AsSingle(1);

            Container.Bind<Deck>()
                .WithId("Infinity")
                .FromMethod(c => new InfinityDeck(
                    (InfinityDeckInfo)Settings.Instance.Deck, 
                    c.Container.ResolveAll<Card>()))
                .AsSingle(2);

            Container.Bind<Rule>()
                .FromMethod(c => new ClassicRule(
                    (ClassicRuleInfo)Settings.Instance.Rule))
                .AsSingle(0);

            Container.Bind<Timer>()
                .FromMethod(c => new InfinityTimer())
                .AsSingle(0);

            Container.Bind<SingleGameExecutor>()
                .ToSelf()
                .AsSingle(0);

            Container.Bind<SingleViewModelUpdater>()
                .ToSelf()
                .AsSingle(0);

            Container.Bind<SinglePlayCardCommand>()
                .ToSelf()
                .AsSingle(0);

            Container.Bind<SingleDiscardCardCommand>()
                .ToSelf()
                .AsSingle(0);

            Container.Bind<GameViewModel>()
                .ToSelf()
                .AsSingle(0);
        }

        private IPlayAction CreatePlayAction(DiContainer container)
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
        }

        private IPlayCardAction CreatePlayCardAction(DiContainer container)
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
}