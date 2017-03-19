﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Arcomage.WebApi.Client.Models.Game
{
    public class GameModel
    {
        public PlayerModel FirstPlayer { get; set; }

        public PlayerModel SecondPlayer { get; set; }

        public HistoryModel History { get; set; }

        public HandModel Hand { get; set; }

        public ResultModel Result { get; set; }

        public class PlayerModel
        {
            public string Name { get; set; }

            public BuildingsModel Buildings { get; set; }

            public ResourcesModel Resources { get; set; }
        }

        public class BuildingsModel
        {
            public int Wall { get; set; }

            public int Tower { get; set; }
        }

        public class ResourcesModel
        {
            public int Quarry { get; set; }

            public int Bricks { get; set; }

            public int Magic { get; set; }

            public int Gems { get; set; }

            public int Dungeons { get; set; }

            public int Recruits { get; set; }
        }

        public class HandModel
        {
            public CardModel[] Cards { get; set; }
        }

        public class HistoryModel
        {
            public CardModel[] Cards { get; set; }
        }

        public class CardModel
        {
            public string Identifier { get; set; }

            public int ResourceKind { get; set; }

            public int ResourcePrice { get; set; }
        }

        public class ResultModel
        {
            public string Identifier { get; set; }

            public int WinPlayer { get; set; }
        }
    }
}