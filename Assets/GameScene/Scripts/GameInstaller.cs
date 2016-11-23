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
using Zenject;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class GameInstaller : Installer<GameInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IArtificialIntelligence>()
                .To<FakeArtificialIntelligence>()
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
                    new ReplacePlayerAction(),
                    new UpdateFinishedAction(c.Container.Resolve<Rule>())))
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
                    c.Container.Resolve<Hand>(PlayerMode.FirstPlayer)))
                .AsSingle(0);

            Container.Bind<Player>()
                .WithId(PlayerMode.SecondPlayer)
                .FromMethod(c => new ComputerPlayer(
                    c.Container.Resolve<IArtificialIntelligence>(),
                    c.Container.Resolve<Rule>().CreateBuildings(),
                    c.Container.Resolve<Rule>().CreateResources(),
                    c.Container.Resolve<Hand>(PlayerMode.SecondPlayer)))
                .AsSingle(1);

            Container.Bind<History>()
                .FromMethod(c => new History(Enumerable.Empty<Card>().ToList()))
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
                .FromMethod(c => c.Container.Resolve<Deck>(c.Container.Resolve<Settings>().DeckMode))
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
                .FromMethod(c => c.Container.Resolve<Rule>(c.Container.Resolve<Settings>().RuleMode))
                .AsSingle(0);

            Container.Bind<Rule>()
                .WithId("EmpiresCapital")
                .FromMethod(c => new ClassicRule(new Buildings(5, 20), new Resources(2, 5, 2, 5, 2, 5), 50, 150))
                .AsSingle(1);
        }
    }

    public class Settings
    {
        public Settings()
        {
            DeckMode = "Classic";
            RuleMode = "EmpiresCapital";
        }

        public string DeckMode { get; set; }

        public string RuleMode { get; set; }
    }
}