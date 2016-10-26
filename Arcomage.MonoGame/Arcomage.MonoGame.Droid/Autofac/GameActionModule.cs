using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Services;
using Autofac;
using static Arcomage.Domain.Entities.PlayerMode;

namespace Arcomage.MonoGame.Droid.Autofac
{
    public class GameActionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(cc => 
                new CompositeGameAction(
                    new VerifyPlayCardGameAction(FirstPlayer),
                    new ActivateCardGameAction(),
                    new UpdateHistoryGameAction(),
                    cc.Resolve<UpdateHistoryViewGameAction>(),
                    new ReplaceCardGameAction(),
                    new UpdateFinishedGameAction(cc.Resolve<GameCondition>(), 
                        new ShowFinishedGameAction(), 
                        new CompositeGameAction(
                            new ReplacePlayerGameAction(
                                new CompositeGameAction(
                                    new UpdateResourcesGameAction(),
                                    new ClearHistoryGameAction())),
                            new PlayGameAction())),
                    cc.Resolve<UpdateViewGameAction>()))
                .Named<IGameAction>("FirstPlayCardGameAction");

            builder.Register(cc =>
                new CompositeGameAction(
                    new VerifyDiscardCardGameAction(FirstPlayer),
                    new UpdateHistoryGameAction(),
                    cc.Resolve<UpdateHistoryViewGameAction>(),
                    new ReplaceCardGameAction(),
                    new UpdateFinishedGameAction(cc.Resolve<GameCondition>(),
                        new ShowFinishedGameAction(),
                        new CompositeGameAction(
                            new ReplacePlayerGameAction(
                                new CompositeGameAction(
                                    new UpdateResourcesGameAction(),
                                    new ClearHistoryGameAction())),
                            new PlayGameAction())),
                    cc.Resolve<UpdateViewGameAction>()))
                .Named<IGameAction>("FirstDiscardCardGameAction");

            builder.Register(cc => 
                new CompositeGameAction(
                    new VerifyPlayCardGameAction(SecondPlayer),
                    new ActivateCardGameAction(),
                    new UpdateHistoryGameAction(),
                    cc.Resolve<UpdateHistoryViewGameAction>(),
                    new ReplaceCardGameAction(),
                    new UpdateFinishedGameAction(cc.Resolve<GameCondition>(),
                        new ShowFinishedGameAction(),
                        new CompositeGameAction(
                            new ReplacePlayerGameAction(
                                new CompositeGameAction(
                                    new UpdateResourcesGameAction(),
                                    new ClearHistoryGameAction())),
                            new PlayGameAction())),
                    cc.Resolve<UpdateViewGameAction>()))
                .Named<IGameAction>("SecondPlayCardGameAction");

            builder.Register(cc =>
                new CompositeGameAction(
                    new VerifyDiscardCardGameAction(SecondPlayer),
                    new UpdateHistoryGameAction(),
                    cc.Resolve<UpdateHistoryViewGameAction>(),
                    new ReplaceCardGameAction(),
                    new UpdateFinishedGameAction(cc.Resolve<GameCondition>(),
                        new ShowFinishedGameAction(),
                        new CompositeGameAction(
                            new ReplacePlayerGameAction(
                                new CompositeGameAction(
                                    new UpdateResourcesGameAction(),
                                    new ClearHistoryGameAction())),
                            new PlayGameAction())),
                    cc.Resolve<UpdateViewGameAction>()))
                .Named<IGameAction>("SecondDiscardCardGameAction");
        }
    }
}