using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain;
using Arcomage.Domain.Actions;
using Arcomage.Domain.ArtificialIntelligence;
using Arcomage.Domain.Decks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Players;
using Arcomage.Domain.Rules;
using Arcomage.Domain.Services;
using Arcomage.Unity.Shared.Scripts;
using Zenject;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class GameInstaller : Installer<GameInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IArtificialIntelligence>()
                .To<ArtificialIntelligence>()
                .AsSingle(0);

            Container.Bind<Card>()
                .To(b => b.AllNonAbstractClasses()
                    .FromAssemblyContaining<Game>())
                .AsSingle(0);

            Container.Bind<IPlayAction>()
                .FromMethod(c => new WhenReplacedPlayerAction(
                    new CompositePlayAction(
                        new ClearHistoryAction(),
                        new UpdateResourcesAction(),
                        new UpdateFinishedAction(c.Container.Resolve<Rule>()))))
                .AsSingle(0);

            Container.Bind<ICardAction>()
                .FromMethod(c => new CompositeCardAction(
                    new ActivateCardAction(),
                    new UpdateHistoryAction(),
                    new ReplaceCardAction(),
                    new UpdateFinishedAction(c.Container.Resolve<Rule>()),
                    new ReplacePlayerAction()))
                .AsSingle(0);

            Container.Bind<IPlayCardCriteria>()
                .To<PlayCardCriteria>()
                .AsSingle(0);

            Container.Bind<IDiscardCardCriteria>()
                .To<DiscardCardCriteria>()
                .AsSingle(0);

            Container.Bind<GameLoop>()
                .ToSelf()
                .AsSingle(0);

            Container.Bind<Game>()
                .FromMethod(c => new Game(
                    c.Container.Resolve<Deck>(),
                    c.Container.Resolve<History>(),
                    c.Container.Resolve<Player>("FirstPlayer"),
                    c.Container.Resolve<Player>("SecondPlayer")))
                .AsSingle();

            Container.Bind<Player>()
                .WithId("FirstPlayer")
                .FromMethod(c => new HumanPlayer(
                    c.Container.Resolve<Rule>().CreateBuildings(),
                    c.Container.Resolve<Rule>().CreateResources(),
                    c.Container.Resolve<Hand>("FirstPlayer"))
                {
                    Identifier = Settings.Instance.FirstPlayer
                })
                .AsSingle(0);

            Container.Bind<Player>()
                .WithId("SecondPlayer")
                .FromMethod(c => new ComputerPlayer(
                    c.Container.Resolve<IArtificialIntelligence>(),
                    c.Container.Resolve<Rule>().CreateBuildings(),
                    c.Container.Resolve<Rule>().CreateResources(),
                    c.Container.Resolve<Hand>("SecondPlayer"))
                {
                    Identifier = Settings.Instance.SecondPlayer
                })
                .AsSingle(1);

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
                .FromMethod(c => new ClassicDeck((ClassicDeckInfo)Settings.Instance.Deck, c.Container.ResolveAll<Card>()))
                .AsSingle(1);

            Container.Bind<Deck>()
                .WithId("Infinity")
                .FromMethod(c => new InfinityDeck((InfinityDeckInfo)Settings.Instance.Deck, c.Container.ResolveAll<Card>()))
                .AsSingle(2);

            Container.Bind<Rule>()
                .FromMethod(c => new ClassicRule((ClassicRuleInfo)Settings.Instance.Rule))
                .AsSingle(0);
        }
    }
}