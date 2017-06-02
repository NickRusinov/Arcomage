using System;
using System.Collections.Generic;
using System.Linq;
using Arcomage.Domain;
using Arcomage.Domain.Players;
using Arcomage.Network;
using Autofac;

namespace Arcomage.WebApi
{
    public class DomainModule : ApplicationModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c =>
                GameBuilderExtensions.GetDefault<GameContext>()
                    .RegisterFirstHumanPlayer("HumanFirstPlayer")
                    .RegisterSecondHumanPlayer("HumanSecondPlayer")
                    .RegisterFirstComputerPlayer("ComputerFirstPlayer")
                    .RegisterSecondComputerPlayer("ComputerSecondPlayer")
                    .RegisterFixedTimer(null, gc => TimeSpan.FromSeconds(30))
                    .RegisterPlayerSet(null, gc => new Random().Next(100) < 50 ? PlayerKind.First : PlayerKind.Second)
                    .WithFirstPlayer(gc => gc.FirstUser.Id == User.ComputerUser.Id ? "ComputerFirstPlayer" : "HumanFirstPlayer")
                    .WithSecondPlayer(gc => gc.SecondUser.Id == User.ComputerUser.Id ? "ComputerSecondPlayer" : "HumanSecondPlayer"))
                .AsSelf()
                .SingleInstance();
        }
    }
}