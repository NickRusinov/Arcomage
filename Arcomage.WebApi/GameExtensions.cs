using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Arcomage.Domain;
using Arcomage.Domain.Cards;
using Arcomage.Domain.Players;
using Arcomage.Network;

namespace Arcomage.WebApi
{
    public static class GameExtensions
    {
        public static string GetIdentifier(this Card card)
        {
            var name = card.GetType().Name;

            if (name.EndsWith("Card"))
                return name.Substring(0, name.Length - 4);

            return name;
        }

        public static string GetIdentifier(this GameResult gameResult)
        {
            if (gameResult.IsTowerBuild)
                return "TowerBuild";

            if (gameResult.IsTowerDestroy)
                return "TowerDestroy";

            if (gameResult.IsResourcesAccumulate)
                return "ResourcesAccumulate";

            return "";
        }

        public static string GetName(this GameContext settings, PlayerKind playerKind)
        {
            if (playerKind == PlayerKind.First)
                return settings.FirstUser.Id.ToString();

            if (playerKind == PlayerKind.Second)
                return settings.SecondUser.Id.ToString();

            return "";
        }

        public static PlayerKind GetPlayerKind(this GameContext gameContext, UserContext userContext)
        {
            if (gameContext.FirstUser.Id == userContext.Id)
                return PlayerKind.First;

            if (gameContext.SecondUser.Id == userContext.Id)
                return PlayerKind.Second;

            throw new InvalidOperationException();
        }
    }
}