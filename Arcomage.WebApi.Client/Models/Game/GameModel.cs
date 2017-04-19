using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Arcomage.WebApi.Client.Models.Game
{
    public class GameModel
    {
        [JsonProperty, JsonRequired]
        public PlayerModel FirstPlayer { get; set; }

        [JsonProperty, JsonRequired]
        public PlayerModel SecondPlayer { get; set; }

        [JsonProperty, JsonRequired]
        public HistoryModel History { get; set; }

        [JsonProperty, JsonRequired]
        public HandModel Hand { get; set; }

        [JsonProperty]
        public ResultModel Result { get; set; }

        [JsonProperty, JsonRequired]
        public int DiscardOnly { get; set; }

        [JsonProperty, JsonRequired]
        public int PlayAgain { get; set; }

        [JsonProperty, JsonRequired]
        public int Version { get; set; }
        
        public class PlayerModel
        {
            [JsonProperty, JsonRequired]
            public string Name { get; set; }

            [JsonProperty, JsonRequired]
            public BuildingsModel Buildings { get; set; }

            [JsonProperty, JsonRequired]
            public ResourcesModel Resources { get; set; }
        }

        public class BuildingsModel
        {
            [JsonProperty, JsonRequired]
            public int Wall { get; set; }

            [JsonProperty, JsonRequired]
            public int Tower { get; set; }

            [JsonProperty, JsonRequired]
            public int MaxWall { get; set; }

            [JsonProperty, JsonRequired]
            public int MaxTower { get; set; }
        }

        public class ResourcesModel
        {
            [JsonProperty, JsonRequired]
            public int Quarry { get; set; }

            [JsonProperty, JsonRequired]
            public int Bricks { get; set; }

            [JsonProperty, JsonRequired]
            public int Magic { get; set; }

            [JsonProperty, JsonRequired]
            public int Gems { get; set; }

            [JsonProperty, JsonRequired]
            public int Dungeons { get; set; }

            [JsonProperty, JsonRequired]
            public int Recruits { get; set; }
        }

        public class HandModel
        {
            [JsonProperty, JsonRequired]
            public CardModel[] Cards { get; set; }
        }

        public class HistoryModel
        {
            [JsonProperty, JsonRequired]
            public HistoryCardModel[] Cards { get; set; }
        }

        public class CardModel
        {
            [JsonProperty, JsonRequired]
            public string Identifier { get; set; }

            [JsonProperty, JsonRequired]
            public int Index { get; set; }

            [JsonProperty, JsonRequired]
            public int ResourceKind { get; set; }

            [JsonProperty, JsonRequired]
            public int ResourcePrice { get; set; }

            [JsonProperty, JsonRequired]
            public bool CanPlay { get; set; }

            [JsonProperty, JsonRequired]
            public bool CanDiscard { get; set; }
        }

        public class HistoryCardModel
        {
            [JsonProperty, JsonRequired]
            public string Identifier { get; set; }

            [JsonProperty, JsonRequired]
            public int Index { get; set; }

            [JsonProperty, JsonRequired]
            public int ResourceKind { get; set; }

            [JsonProperty, JsonRequired]
            public int ResourcePrice { get; set; }

            [JsonProperty, JsonRequired]
            public bool IsPlayed { get; set; }
        }

        public class ResultModel
        {
            [JsonProperty, JsonRequired]
            public string Identifier { get; set; }

            [JsonProperty, JsonRequired]
            public string WinPlayer { get; set; }
        }
    }
}