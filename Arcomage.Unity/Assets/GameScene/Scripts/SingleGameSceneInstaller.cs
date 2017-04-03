using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain;
using Arcomage.Domain.Actions;
using Arcomage.Domain.Decks;
using Arcomage.Domain.Players;
using Arcomage.Domain.Rules;
using Arcomage.Domain.Services;
using Arcomage.Unity.GameScene.Commands;
using Arcomage.Unity.GameScene.ViewModels;
using Arcomage.Unity.Shared.Scripts;
using Zenject;

namespace Arcomage.Unity.GameScene.Scripts
{
    /// <summary>
    /// Модуль, устанавливающий зависимости игровой логики
    /// </summary>
    public class SingleGameSceneInstaller : Installer<SingleGameSceneInstaller>
    {
        /// <summary>
        /// Настройка привязок контейнера внедрения зависимостей
        /// </summary>
        public override void InstallBindings()
        {
            Container.Bind<ClassicRuleInfo>()
                .FromMethod(c => (ClassicRuleInfo)Settings.Instance.Single.Rule);

            Container.Bind<GameBuilder>()
                .FromMethod(c => GameBuilderExtensions.GetDefault()
                    .RegisterFirstHumanPlayer(null)
                    .RegisterSecondComputerPlayer(null)
                    .RegisterPlayerSet(null, () => new Random().Next(100) < 50 ? PlayerKind.First : PlayerKind.Second)
                    .RegisterClassicRule(null, () => (ClassicRuleInfo)Settings.Instance.Single.Rule)
                    .RegisterClassicDeck("ClassicDeck", () => (ClassicDeckInfo)Settings.Instance.Single.Deck)
                    .RegisterInfinityDeck("InfinityDeck", () => (InfinityDeckInfo)Settings.Instance.Single.Deck)
                    .With<Deck>(() => Settings.Instance.Single.Deck.Identifier + "Deck"))
                .AsSingle(0);

            Container.Bind<GameBuilderContext>()
                .FromMethod(c => c.Container.Resolve<GameBuilder>().CreateContext())
                .AsSingle(0);

            Container.Bind<Game>()
                .FromMethod(c => c.Container.Resolve<GameBuilderContext>().Resolve<Game>())
                .AsSingle(0);

            Container.Bind<IPlayAction>()
                .FromMethod(c => c.Container.Resolve<GameBuilderContext>().Resolve<IPlayAction>())
                .AsSingle(0);

            Container.Bind<IPlayCardCriteria>()
                .FromMethod(c => c.Container.Resolve<GameBuilderContext>().Resolve<IPlayCardCriteria>())
                .AsSingle(0);

            Container.Bind<IDiscardCardCriteria>()
                .FromMethod(c => c.Container.Resolve<GameBuilderContext>().Resolve<IDiscardCardCriteria>())
                .AsSingle(0);

            Container.Bind<SinglePlayCardCommand>()
                .FromMethod(c => new SinglePlayCardCommand(
                    (HumanPlayer)c.Container.Resolve<Game>().Players.FirstPlayer))
                .AsSingle(0);

            Container.Bind<SingleDiscardCardCommand>()
                .FromMethod(c => new SingleDiscardCardCommand(
                    (HumanPlayer)c.Container.Resolve<Game>().Players.FirstPlayer))
                .AsSingle(0);

            Container.Bind<SingleGameExecutor>()
                .ToSelf()
                .AsSingle(0);

            Container.Bind<SingleViewModelUpdater>()
                .ToSelf()
                .AsSingle(0);

            Container.Bind<GameViewModel>()
                .ToSelf()
                .AsSingle(0);
        }
    }
}