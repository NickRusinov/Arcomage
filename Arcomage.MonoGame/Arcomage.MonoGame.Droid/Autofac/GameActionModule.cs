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
                    new VerifyPlayCardGameAction(cc.Resolve<Game>(), cc.ResolveKeyed<Player>(FirstPlayer)),
                    new ActivateCardGameAction(cc.Resolve<Game>(), cc.ResolveKeyed<Player>(FirstPlayer)),
                    new ReplaceCardGameAction(cc.Resolve<Game>(), cc.ResolveKeyed<Player>(FirstPlayer)),
                    new UpdateFinishedGameAction(cc.Resolve<Game>(), cc.Resolve<GameCondition>()),
                    new ReplacePlayerGameAction(cc.Resolve<Game>()),
                    cc.Resolve<UpdateViewGameAction>()))
                .Named<IGameAction>("PlayCardGameAction");

            builder.Register(cc =>
                new CompositeGameAction(
                    new VerifyDiscardCardGameAction(cc.Resolve<Game>(), cc.ResolveKeyed<Player>(FirstPlayer)),
                    new ReplaceCardGameAction(cc.Resolve<Game>(), cc.ResolveKeyed<Player>(FirstPlayer)),
                    new UpdateFinishedGameAction(cc.Resolve<Game>(), cc.Resolve<GameCondition>()),
                    new ReplacePlayerGameAction(cc.Resolve<Game>()),
                    cc.Resolve<UpdateViewGameAction>()))
                .Named<IGameAction>("DiscardCardGameAction");
        }
    }
}