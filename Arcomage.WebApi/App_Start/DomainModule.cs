using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Arcomage.Domain;
using Arcomage.Domain.Players;
using Arcomage.Network;
using Autofac;

namespace Arcomage.WebApi
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c =>
                GameBuilderExtensions.GetDefault<GameContext>()
                    .RegisterFirstHumanPlayer(UserKind.Human + "FirstPlayer")
                    .RegisterSecondHumanPlayer(UserKind.Human + "SecondPlayer")
                    .RegisterFirstComputerPlayer(UserKind.Computer + "FirstPlayer")
                    .RegisterSecondComputerPlayer(UserKind.Computer + "SecondPlayer")
                    .RegisterFixedTimer(null, gc => TimeSpan.FromSeconds(30))
                    .RegisterPlayerSet(null, gc => new Random().Next(100) < 50 ? PlayerKind.First : PlayerKind.Second)
                    .WithFirstPlayer(gc => gc.FirstUser.Kind + "FirstPlayer")
                    .WithSecondPlayer(gc => gc.SecondUser.Kind + "SecondPlayer"))
                .AsSelf()
                .SingleInstance();
        }
    }
}