﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Arcomage.Network.Games;
using Arcomage.WebApi.Models.Game;

namespace Arcomage.WebApi.Controllers
{
    [Authorize]
    public class GameApiController : ApplicationApiController
    {
        private readonly IGetGameByUserIdQuery getGameByUserIdQuery;

        private readonly Network.Domain.IGetGameByIdQuery getGameByIdQuery;
        
        public GameApiController(IGetGameByUserIdQuery getGameByUserIdQuery, Network.Domain.IGetGameByIdQuery getGameByIdQuery)
        {
            this.getGameByUserIdQuery = getGameByUserIdQuery;
            this.getGameByIdQuery = getGameByIdQuery;
        }

        [HttpGet, Route("~/api/game/{gameId:guid}")]
        public async Task<GameModel> GetGame(Guid gameId)
        {
            var gameContext = await getGameByUserIdQuery.Get(Identity.Id) ?? 
                throw new HttpException(400, "Not found active game");

            var game = await getGameByIdQuery.Get(gameContext.Id) ?? 
                throw new HttpException(400, "Not found active game");

            var model = new GameModel();
            Mapper.Map(game, model);
            Mapper.Map(gameContext, model);

            return model;
        }
    }
}