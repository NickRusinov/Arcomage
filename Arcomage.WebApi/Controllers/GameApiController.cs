using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Arcomage.WebApi.Models.Game;

namespace Arcomage.WebApi.Controllers
{
    [Authorize]
    public class GameApiController : ApplicationApiController
    {
        [HttpGet, Route("~/api/game/{gameId}")]
        public GameModel GetGame(Guid gameId)
        {
            var gameModel = new GameModel
            {
                FirstPlayer = new GameModel.PlayerModel
                {
                    Name = "Name x",
                    Buildings = new GameModel.BuildingsModel
                    {
                        Wall = 15,
                        Tower = 43,
                        MaxWall = 50,
                        MaxTower = 50,
                    },
                    Resources = new GameModel.ResourcesModel
                    {
                        Quarry = 4,
                        Bricks = 15,
                        Magic = 2,
                        Gems = 27,
                        Dungeons = 3,
                        Recruits = 2,
                    },
                },
                SecondPlayer = new GameModel.PlayerModel
                {
                    Name = "Name y",
                    Buildings = new GameModel.BuildingsModel
                    {
                        Wall = 20,
                        Tower = 32,
                        MaxWall = 50,
                        MaxTower = 50,
                    },
                    Resources = new GameModel.ResourcesModel
                    {
                        Quarry = 1,
                        Bricks = 2,
                        Magic = 3,
                        Gems = 33,
                        Dungeons = 1,
                        Recruits = 5,
                    },
                },
                Hand = new GameModel.HandModel
                {
                    Cards = new[]
                    {
                        new GameModel.CardModel
                        {
                            Identifier = "Apprentice",
                            Index = 3,
                            ResourceKind = 1,
                            ResourcePrice = 2,
                        },
                        new GameModel.CardModel
                        {
                            Identifier = "Apprentice",
                            Index = 4,
                            ResourceKind = 1,
                            ResourcePrice = 2,
                        },
                        new GameModel.CardModel
                        {
                            Identifier = "Apprentice",
                            Index = 5,
                            ResourceKind = 1,
                            ResourcePrice = 2,
                        },
                        new GameModel.CardModel
                        {
                            Identifier = "Apprentice",
                            Index = 6,
                            ResourceKind = 1,
                            ResourcePrice = 2,
                        },
                        new GameModel.CardModel
                        {
                            Identifier = "Apprentice",
                            Index = 7,
                            ResourceKind = 1,
                            ResourcePrice = 2,
                        },
                        new GameModel.CardModel
                        {
                            Identifier = "Apprentice",
                            Index = 8,
                            ResourceKind = 1,
                            ResourcePrice = 2,
                        },
                    }
                },
                History = new GameModel.HistoryModel
                {
                    Cards = new[]
                    {
                        new GameModel.HistoryCardModel
                        {
                            Identifier = "Apprentice",
                            Index = 2,
                            ResourceKind = 1,
                            ResourcePrice = 2,
                            IsPlayed = true,
                        },
                    }
                },
                Result = null,
            };

            return gameModel;
        }
    }
}