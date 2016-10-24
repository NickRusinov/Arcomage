using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                    cc.Resolve<ActivateCardGameAction>(),
                    cc.Resolve<ReplaceCardGameAction>(),
                    cc.Resolve<UpdateFinishedGameAction>(),
                    cc.Resolve<ReplacePlayerGameAction>(),
                    cc.Resolve<UpdateViewGameAction>(),
                    cc.Resolve<PlayGameAction>()))
                .Named<IGameAction>("FirstPlayCardGameAction");

            builder.Register(cc =>
                new CompositeGameAction(
                    new VerifyDiscardCardGameAction(FirstPlayer),
                    cc.Resolve<ReplaceCardGameAction>(),
                    cc.Resolve<UpdateFinishedGameAction>(),
                    cc.Resolve<ReplacePlayerGameAction>(),
                    cc.Resolve<UpdateViewGameAction>(),
                    cc.Resolve<PlayGameAction>()))
                .Named<IGameAction>("FirstDiscardCardGameAction");

            builder.Register(cc => 
                new CompositeGameAction(
                    new VerifyPlayCardGameAction(SecondPlayer),
                    cc.Resolve<ActivateCardGameAction>(),
                    cc.Resolve<ReplaceCardGameAction>(),
                    cc.Resolve<UpdateFinishedGameAction>(),
                    cc.Resolve<ReplacePlayerGameAction>(),
                    cc.Resolve<UpdateViewGameAction>(),
                    cc.Resolve<PlayGameAction>()))
                .Named<IGameAction>("SecondPlayCardGameAction");

            builder.Register(cc =>
                new CompositeGameAction(
                    new VerifyDiscardCardGameAction(SecondPlayer),
                    cc.Resolve<ReplaceCardGameAction>(),
                    cc.Resolve<UpdateFinishedGameAction>(),
                    cc.Resolve<ReplacePlayerGameAction>(),
                    cc.Resolve<UpdateViewGameAction>(),
                    cc.Resolve<PlayGameAction>()))
                .Named<IGameAction>("SecondDiscardCardGameAction");
        }
    }
}