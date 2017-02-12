using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Unity.Shared.Scripts;

namespace Arcomage.Unity.GameScene.Scripts
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

        public static string GetName(this PlayerKind playerKind)
        {
            if (playerKind == PlayerKind.First)
                return Settings.Instance.FirstPlayer;

            if (playerKind == PlayerKind.Second)
                return Settings.Instance.SecondPlayer;

            return "";
        }
    }
}
