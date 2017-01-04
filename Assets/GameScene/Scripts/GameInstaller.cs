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
                .FromMethod(c => new FakeArtificialIntelligence(
                    new PlayCardCriteria(PlayerMode.SecondPlayer)))
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
                .FromMethod(c => new PlayCardCriteria(PlayerMode.FirstPlayer))
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
                    c.Container.Resolve<Player>(PlayerMode.FirstPlayer),
                    c.Container.Resolve<Player>(PlayerMode.SecondPlayer)))
                .AsSingle();

            Container.Bind<Player>()
                .WithId(PlayerMode.FirstPlayer)
                .FromMethod(c => new HumanPlayer(
                    c.Container.Resolve<Rule>().CreateBuildings(),
                    c.Container.Resolve<Rule>().CreateResources(),
                    c.Container.Resolve<Hand>(PlayerMode.FirstPlayer))
                {
                    Identifier = Settings.Instance.FirstPlayer
                })
                .AsSingle(0);

            Container.Bind<Player>()
                .WithId(PlayerMode.SecondPlayer)
                .FromMethod(c => new ComputerPlayer(
                    c.Container.Resolve<IArtificialIntelligence>(),
                    c.Container.Resolve<Rule>().CreateBuildings(),
                    c.Container.Resolve<Rule>().CreateResources(),
                    c.Container.Resolve<Hand>(PlayerMode.SecondPlayer))
                {
                    Identifier = Settings.Instance.SecondPlayer
                })
                .AsSingle(1);

            Container.Bind<History>()
                .FromMethod(c => new History(Enumerable.Empty<HistoryCard>().ToList()))
                .AsSingle(0);

            Container.Bind<Hand>()
                .WithId(PlayerMode.FirstPlayer)
                .FromMethod(c => new Hand(
                    Enumerable.Repeat(c.Container.Resolve<Deck>(), 6).Select(d => d.PopCard(null)).ToList()))
                .AsSingle(0);

            Container.Bind<Hand>()
                .WithId(PlayerMode.SecondPlayer)
                .FromMethod(c => new Hand(
                    Enumerable.Repeat(c.Container.Resolve<Deck>(), 6).Select(d => d.PopCard(null)).ToList()))
                .AsSingle(1);

            Container.Bind<Deck>()
                .FromMethod(c => c.Container.Resolve<Deck>(Settings.Instance.Deck.Identifier))
                .AsSingle(0);

            Container.Bind<Deck>()
                .WithId("Classic")
                .FromMethod(c => new ClassicDeck(new Random(), c.Container.ResolveAll<Card>()))
                .AsSingle(1);

            Container.Bind<Deck>()
                .WithId("Infinity")
                .FromMethod(c => new InfinityDeck(new Random(), c.Container.ResolveAll<Card>()))
                .AsSingle(2);

            Container.Bind<Rule>()
                .FromMethod(c => new ClassicRule(
                    new Buildings(
                        Settings.Instance.Rule.Wall, Settings.Instance.Rule.Tower),
                    new Resources(
                        Settings.Instance.Rule.Quarry, Settings.Instance.Rule.Bricks, 
                        Settings.Instance.Rule.Magic, Settings.Instance.Rule.Gems, 
                        Settings.Instance.Rule.Dungeons, Settings.Instance.Rule.Recruits),
                    Settings.Instance.Rule.MaxTower, Settings.Instance.Rule.MaxResources))
                .AsSingle(0);
        }
    }
}